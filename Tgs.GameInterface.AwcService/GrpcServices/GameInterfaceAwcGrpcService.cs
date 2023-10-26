using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices;

public class GameInterfaceAwcGrpcService : GameInterfaceAwcService.GameInterfaceAwcServiceBase
{
    private readonly IQueryService<AllBalanceQuery, AllBalanceResult> _allBalanceService;
    private readonly IGetService<PlayerBalanceQuery, PlayerBalanceResult> _balanceService;
    private readonly ICommandService<PlayerCreateByBetLimitCommand> _createPlayerByBetLimitService;
    private readonly ICommandService<PlayerCreateCommand> _createPlayerService;
    private readonly IGetService<FundInQuery, FundResult> _fundInService;
    private readonly IGetService<FundStatusQuery, bool> _fundOrderCheckingService;
    private readonly IGetService<FundOutQuery, FundResult> _fundOutService;
    private readonly IGetService<GameUrlLobbyByLiveQuery, GameUrlResult> _gameUrlByLiveService;
    private readonly IGetService<GameUrlQuery, GameUrlResult> _gameUrlService;
    private readonly ILogger<GameInterfaceAwcGrpcService> _logger;
    private readonly ICommandService<LogoutCommand> _logoutService;

    public GameInterfaceAwcGrpcService(
        ILogger<GameInterfaceAwcGrpcService> logger,
        IGetService<FundInQuery, FundResult> fundInService,
        IGetService<FundStatusQuery, bool> fundOrderCheckingService,
        IGetService<FundOutQuery, FundResult> fundOutService,
        ICommandService<LogoutCommand> logoutService,
        IGetService<PlayerBalanceQuery, PlayerBalanceResult> balanceService,
        IQueryService<AllBalanceQuery, AllBalanceResult> allBalanceService,
        ICommandService<PlayerCreateCommand> createPlayerService,
        ICommandService<PlayerCreateByBetLimitCommand> createPlayerByBetLimitService,
        IGetService<GameUrlQuery, GameUrlResult> gameUrlService,
        IGetService<GameUrlLobbyByLiveQuery, GameUrlResult> gameUrlByLiveService
        )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fundInService = fundInService ?? throw new ArgumentNullException(nameof(fundInService));
        _fundOrderCheckingService = fundOrderCheckingService ?? throw new ArgumentNullException(nameof(fundOrderCheckingService));
        _fundOutService = fundOutService ?? throw new ArgumentNullException(nameof(fundOutService));
        _logoutService = logoutService ?? throw new ArgumentNullException(nameof(logoutService));
        _balanceService = balanceService ?? throw new ArgumentNullException(nameof(balanceService));
        _allBalanceService = allBalanceService ?? throw new ArgumentNullException(nameof(allBalanceService));
        _createPlayerService = createPlayerService ?? throw new ArgumentNullException(nameof(createPlayerService));
        _createPlayerByBetLimitService = createPlayerByBetLimitService ?? throw new ArgumentNullException(nameof(createPlayerByBetLimitService));
        _gameUrlService = gameUrlService ?? throw new ArgumentNullException(nameof(gameUrlService));
        _gameUrlByLiveService = gameUrlByLiveService ?? throw new ArgumentNullException(nameof(gameUrlByLiveService));
    }

    public override async Task<AllBalancesReply> AllBalances(AllBalancesRequest request, ServerCallContext context)
    {
        var query = new AllBalanceQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert);

        var balances = await _allBalanceService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<AllBalanceResult>();

        var reply = new AllBalancesReply();

        if (balances.Any())
        {
            foreach (var balance in balances)
            {
                reply.Items.Add(new BalanceInfo
                {
                    PlayerCode = balance.PlayerCode,
                    Balance = balance.Balance,
                    LastModified = balance.LastModified.ToUniversalTime().ToTimestamp()
                });
            }
        }

        return reply;
    }

    public override Task<CheckingServiceReply> CheckingService(
        CheckingServiceRequest request,
    ServerCallContext context)
    {
        _logger.LogWarning("LogOn:{logOn} Message: Create a check connection.({machineName})", DateTime.Now.ToString("o"), request.MachineName);

        return Task.FromResult(new CheckingServiceReply
        {
            MachineName = Environment.MachineName
        });
    }

    public override async Task<FundReply> FundIn(FundRequest request, ServerCallContext context)
    {
        var result = await _fundInService.GetAsync(new FundInQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode,
            request.OrderId,
            request.Amount)).ConfigureAwait(false);

        return new FundReply()
        {
            OrderId = result.OrderId,
            GameProviderTransactionId = result.GameProviderTransactionId,
            Amount = result.Amount,
            CurrentBalance = result.CurrentBalance,
            Resp = result.Resp
        };
    }

    public override async Task<FundReply> FundOut(FundRequest request, ServerCallContext context)
    {
        var result = await _fundOutService.GetAsync(new FundOutQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode,
            request.OrderId,
            request.Amount)).ConfigureAwait(false);

        return new FundReply()
        {
            OrderId = result.OrderId,
            GameProviderTransactionId = result.GameProviderTransactionId,
            Amount = result.Amount,
            CurrentBalance = result.CurrentBalance,
            Resp = result.Resp
        };
    }

    public override async Task<BaseReply> FundStatus(FundStatusRequest request, ServerCallContext context)

    {
        var query = new FundStatusQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.OrderId);

        var result = await _fundOrderCheckingService.GetAsync(
            query,
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false);

        return new BaseReply()
        {
            State = result
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcCockfight(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlLobbyByLiveQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            ExternalGameId: "SV-LIVE-001",
            BetLimit: request.BetLimit,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcFs(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_FS,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcKm(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_KM,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcLudo(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_LUDO,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcPgs(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_PGS,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcRcb(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlLobbyByLiveQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_RCB,
            ExternalGameId: "HRB-LIVE-001",
            BetLimit: request.BetLimit,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcSg(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlLobbyByLiveQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_SG,
            ExternalGameId: "MX-LIVE-002",
            BetLimit: request.BetLimit,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcSpade(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_SPADE,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcVenus(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlLobbyByLiveQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_VENUS,
            ExternalGameId: "VN-LIVE-001",
            BetLimit: request.BetLimit,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcYl(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_YL,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl
        };
    }

    public override async Task<PlayerBalanceReply> PlayerBalance(PlayerBalanceRequest request, ServerCallContext context)
    {
        var result = await _balanceService.GetAsync(new PlayerBalanceQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode)).ConfigureAwait(false);

        return new PlayerBalanceReply()
        {
            IsPlayerExist = result.IsPlayerExist,
            Balance = result.Balance
        };
    }

    public override async Task<BaseReply> PlayerCreate(PlayerCreateRequest request, ServerCallContext context)
    {
        var command = new PlayerCreateCommand(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            UserName: request.UserName,
            Currency: request.Currency,
            Language: request.Language);

        await _createPlayerService.ExecuteAsync(
            command,
            context.CancellationToken)
            .ConfigureAwait(false);

        return new BaseReply()
        {
            State = true
        };
    }

    public override async Task<BaseReply> PlayerCreateByBetLimit(PlayerCreateByBetLimitRequest request, ServerCallContext context)
    {
        var command = new PlayerCreateByBetLimitCommand(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            UserName: request.UserName,
            Currency: request.Currency,
            BetLimit: request.BetLimit,
            Language: request.Language);

        await _createPlayerByBetLimitService.ExecuteAsync(
            command,
            context.CancellationToken)
            .ConfigureAwait(false);

        return new BaseReply()
        {
            State = true
        };
    }

    public override async Task<BaseReply> PlayerLogout(PlayerLogoutRequest request, ServerCallContext context)
    {
        await _logoutService.ExecuteAsync(new LogoutCommand(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode)).ConfigureAwait(false);

        return new BaseReply()
        {
            State = true
        };
    }
}
