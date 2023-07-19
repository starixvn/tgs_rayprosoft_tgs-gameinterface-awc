using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices;

public class GameInterfaceAwcGrpcService : GameInterfaceAwcService.GameInterfaceAwcServiceBase
{
    private readonly IQueryService<AllBalanceQuery, AllBalance> _allBalanceService;
    private readonly IGetService<BalanceQuery, BalanceResult> _balanceService;
    private readonly ICommandService<CreatePlayerByBetLimitCommand> _createPlayerByBetLimitService;
    private readonly ICommandService<CreatePlayerCommand> _createPlayerService;
    private readonly IGetService<FundInQuery, FundInResult> _fundInService;
    private readonly IGetService<FundOrderCheckingQuery, bool> _fundOrderCheckingService;
    private readonly IGetService<FundOutQuery, FundOutResult> _fundOutService;
    private readonly IGetService<GameUrlByLiveQuery, GameUrlResult> _gameUrlByLiveService;
    private readonly IGetService<GameUrlQuery, GameUrlResult> _gameUrlService;
    private readonly ILogger<GameInterfaceAwcGrpcService> _logger;
    private readonly ICommandService<LogoutCommand> _logoutService;

    public GameInterfaceAwcGrpcService(
        ILogger<GameInterfaceAwcGrpcService> logger,
        IGetService<FundInQuery, FundInResult> fundInService,
        IGetService<FundOrderCheckingQuery, bool> fundOrderCheckingService,
        IGetService<FundOutQuery, FundOutResult> fundOutService,
        ICommandService<LogoutCommand> logoutService,
        IGetService<BalanceQuery, BalanceResult> balanceService,
        IQueryService<AllBalanceQuery, AllBalance> allBalanceService,
        ICommandService<CreatePlayerCommand> createPlayerService,
        ICommandService<CreatePlayerByBetLimitCommand> createPlayerByBetLimitService,
        IGetService<GameUrlQuery, GameUrlResult> gameUrlService,
        IGetService<GameUrlByLiveQuery, GameUrlResult> gameUrlByLiveService
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

    public override async Task<BaseReply> CreatePlayer(CreatePlayerRequest request, ServerCallContext context)
    {
        await _createPlayerService.ExecuteAsync(new CreatePlayerCommand(
                   new(request.ApiUrl),
                   request.AgentId,
                   request.Cert,
                   request.PlayerCode,
                   request.UserName,
                   request.Currency,
                   request.Language)).ConfigureAwait(false);

        return new BaseReply()
        {
            Success = true
        };
    }

    public override async Task<BaseReply> CreatePlayerByBetLimit(CreatePlayerByBetLimitRequest request, ServerCallContext context)
    {
        await _createPlayerByBetLimitService.ExecuteAsync(new CreatePlayerByBetLimitCommand(
                   new(request.ApiUrl),
                   request.AgentId,
                   request.Cert,
                   request.PlayerCode,
                   request.UserName,
                   request.Currency,
                   request.BetLimit,
                   request.Language)).ConfigureAwait(false);

        return new BaseReply()
        {
            Success = true
        };
    }

    public override async Task<FundReply> FundIn(FundRequest request, ServerCallContext context)
    {
        var result = await _fundInService.GetAsync(new FundInQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode,
            request.TransactionId,
            request.Amount)).ConfigureAwait(false);

        return new FundReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            TransactionId = result.TransactionId ?? string.Empty,
            GameProviderTransactionId = result.GameProviderTransactionId ?? string.Empty,
            Amount = result.Amount ?? decimal.MinusOne,
            CurrentBalance = result.CurrentBalance ?? decimal.MinusOne,
        };
    }

    public override async Task<FundOrderCheckingReply> FundOrderChecking(FundOrderCheckingRequest request, ServerCallContext context)

    {
        var result = await _fundOrderCheckingService.GetAsync(new FundOrderCheckingQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.TransactionId)).ConfigureAwait(false);

        return new FundOrderCheckingReply()
        {
            Exist = result
        };
    }

    public override async Task<FundReply> FundOut(FundRequest request, ServerCallContext context)
    {
        var result = await _fundOutService.GetAsync(new FundOutQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode,
            request.TransactionId,
            request.Amount)).ConfigureAwait(false);

        return new FundReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            TransactionId = result.TransactionId ?? string.Empty,
            GameProviderTransactionId = result.GameProviderTransactionId ?? string.Empty,
            Amount = result.Amount ?? decimal.MinusOne,
            CurrentBalance = result.CurrentBalance ?? decimal.MinusOne,
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcAeLotto(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_AELOTTO,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcAws(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_AWS,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlByAwcFacai(GameUrlRequest request, ServerCallContext context)
    {
        var result = await _gameUrlService.GetAsync(new GameUrlQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            PlayerCode: request.PlayerCode,
            IsMobileLogin: request.IsMobileLogin,
            BackUrl: request.BackUrl,
            Platform: AwcPlatforms.AWC_FACAI,
            ExternalGameId: request.ExternalGameId,
            Language: request.Language
            )).ConfigureAwait(false);

        return new GameUrlReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlByLiveLobbyByAwcCockfight(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlByLiveQuery(
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlLiveLobbyByAwcRcb(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlByLiveQuery(
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlLiveLobbyByAwcSg(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlByLiveQuery(
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<GameUrlReply> GameUrlLiveLobbyByAwcVenus(GameUrlByLiveLobbyRequest request, ServerCallContext context)
    {
        var result = await _gameUrlByLiveService.GetAsync(new GameUrlByLiveQuery(
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
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            GameUrl = result.GameUrl ?? string.Empty,
        };
    }

    public override async Task<BalanceReply> GetBalance(BalanceRequest request, ServerCallContext context)
    {
        var result = await _balanceService.GetAsync(new BalanceQuery(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode)).ConfigureAwait(false);

        return new BalanceReply()
        {
            Success = result.Success,
            Message = result.Message ?? string.Empty,
            IsPlayerExist = result.IsPlayerExist,
            Balance = result.Balance ?? decimal.Zero,
        };
    }

    public override async Task<BalancesReply> GetBalances(BalancesRequest request, ServerCallContext context)
    {
        var balances = await _allBalanceService
            .QueryAsync(
            query: new AllBalanceQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<AllBalance>();

        var reply = new BalancesReply();

        if (balances.Any())
        {
            foreach (var balance in balances)
            {
                reply.Items.Add(new BalanceRecord
                {
                    UserId = balance.UserId,
                    Balance = balance.Balance,
                    LastModified = balance.LastModified.ToUniversalTime().ToTimestamp()
                });
            }
            return reply;
        }

        return reply;
    }

    public override async Task<BaseReply> KickPlayer(KickPlayerRequest request, ServerCallContext context)
    {
        await _logoutService.ExecuteAsync(new LogoutCommand(
            new(request.ApiUrl),
            request.AgentId,
            request.Cert,
            request.PlayerCode)).ConfigureAwait(false);

        return new BaseReply()
        {
            Success = true
        };
    }
}
