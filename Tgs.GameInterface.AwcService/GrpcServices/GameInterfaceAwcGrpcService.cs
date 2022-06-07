using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices
{
    public class GameInterfaceAwcGrpcService : GameInterfaceAwcService.GameInterfaceAwcServiceBase
    {
        private readonly IGetService<BalanceQuery, BalanceResult> _balanceService;
        private readonly ICommandService<CreatePlayerByBetLimitCommand> _createPlayerByBetLimitService;
        private readonly ICommandService<CreatePlayerCommand> _createPlayerService;
        private readonly IGetService<FundInQuery, FundInResult> _fundInService;
        private readonly IGetService<FundOrderCheckingQuery, bool> _fundOrderCheckingService;
        private readonly IGetService<FundOutQuery, FundOutResult> _fundOutService;
        private readonly IGetService<GameUrlByLiveLobbyQuery, GameUrlResult> _gameUrlByLiveLobbyService;
        private readonly IGetService<GameUrlByLiveQuery, GameUrlResult> _gameUrlByLiveService;
        private readonly IGetService<GameUrlByLottoLobbyQuery, GameUrlResult> _gameUrlByLottoLobbyService;
        private readonly IGetService<GameUrlQuery, GameUrlResult> _gameUrlService;
        private readonly ICommandService<LogoutCommand> _logoutService;

        public GameInterfaceAwcGrpcService(
            IGetService<FundInQuery, FundInResult> fundInService,
            IGetService<FundOrderCheckingQuery, bool> fundOrderCheckingService,
            IGetService<FundOutQuery, FundOutResult> fundOutService,
            ICommandService<LogoutCommand> logoutService,
            IGetService<BalanceQuery, BalanceResult> balanceService,
            ICommandService<CreatePlayerCommand> createPlayerService,
            ICommandService<CreatePlayerByBetLimitCommand> createPlayerByBetLimitService,
            IGetService<GameUrlQuery, GameUrlResult> gameUrlService,
            IGetService<GameUrlByLiveLobbyQuery, GameUrlResult> gameUrlByLiveLobbyService,
            IGetService<GameUrlByLottoLobbyQuery, GameUrlResult> gameUrlByLottoLobbyService,
            IGetService<GameUrlByLiveQuery, GameUrlResult> gameUrlByLiveService
            )
        {
            _fundInService = fundInService ?? throw new ArgumentNullException(nameof(fundInService));
            _fundOrderCheckingService = fundOrderCheckingService ?? throw new ArgumentNullException(nameof(fundOrderCheckingService));
            _fundOutService = fundOutService ?? throw new ArgumentNullException(nameof(fundOutService));
            _logoutService = logoutService ?? throw new ArgumentNullException(nameof(logoutService));
            _balanceService = balanceService ?? throw new ArgumentNullException(nameof(balanceService));
            _createPlayerService = createPlayerService ?? throw new ArgumentNullException(nameof(createPlayerService));
            _createPlayerByBetLimitService = createPlayerByBetLimitService ?? throw new ArgumentNullException(nameof(createPlayerByBetLimitService));
            _gameUrlService = gameUrlService ?? throw new ArgumentNullException(nameof(gameUrlService));
            _gameUrlByLiveLobbyService = gameUrlByLiveLobbyService ?? throw new ArgumentNullException(nameof(gameUrlByLiveLobbyService));
            _gameUrlByLottoLobbyService = gameUrlByLottoLobbyService ?? throw new ArgumentNullException(nameof(gameUrlByLottoLobbyService));
            _gameUrlByLiveService = gameUrlByLiveService ?? throw new ArgumentNullException(nameof(gameUrlByLiveService));
        }

        public override async Task<GameInterfaceAwcServiceReply> CreatePlayer(GameInterfaceAwcServiceCreatePlayerRequest request, ServerCallContext context)
        {
            await _createPlayerService.ExecuteAsync(new CreatePlayerCommand(
                       new(request.ApiUrl),
                       request.AgentId,
                       request.Cert,
                       request.PlayerCode,
                       request.UserName,
                       request.Currency,
                       request.Language)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceReply()
            {
                Success = true
            };
        }

        public override async Task<GameInterfaceAwcServiceReply> CreatePlayerByBetLimit(GameInterfaceAwcServiceCreatePlayerByBetLimitRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceReply()
            {
                Success = true
            };
        }

        public override async Task<GameInterfaceAwcServiceFundReply> FundIn(GameInterfaceAwcServiceFundRequest request, ServerCallContext context)
        {
            var result = await _fundInService.GetAsync(new FundInQuery(
                new(request.ApiUrl),
                request.AgentId,
                request.Cert,
                request.PlayerCode,
                request.TransactionId,
                request.Amount)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceFundReply()
            {
                Success = result.Success,
                Message = result.Message,
                TransactionId = result.TransactionId,
                GameProductTransactionId = result.GameProductTransactionId,
                Amount = result.Amount,
                CurrentBalance = result.CurrentBalance
            };
        }

        public override async Task<GameInterfaceAwcServiceFundOrderCheckingReply> FundOrderChecking(GameInterfaceAwcServiceFundOrderCheckingRequest request, ServerCallContext context)

        {
            var result = await _fundOrderCheckingService.GetAsync(new FundOrderCheckingQuery(
                new(request.ApiUrl),
                request.AgentId,
                request.Cert,
                request.TransactionId)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceFundOrderCheckingReply()
            {
                Exist = result
            };
        }

        public override async Task<GameInterfaceAwcServiceFundReply> FundOut(GameInterfaceAwcServiceFundRequest request, ServerCallContext context)
        {
            var result = await _fundOutService.GetAsync(new FundOutQuery(
                new(request.ApiUrl),
                request.AgentId,
                request.Cert,
                request.PlayerCode,
                request.TransactionId,
                request.Amount)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceFundReply()
            {
                Success = result.Success,
                Message = result.Message,
                TransactionId = result.TransactionId,
                GameProductTransactionId = result.GameProductTransactionId,
                Amount = result.Amount,
                CurrentBalance = result.CurrentBalance
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAeLotto(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAws(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFacai(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFs(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcKm(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcLudo(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcPgs(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcSpade(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcYl(GameInterfaceAwcServiceGameUrlRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcCockfight(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcRcb(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, ServerCallContext context)
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

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcVenus(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, ServerCallContext context)
        {
            var result = await _gameUrlByLiveLobbyService.GetAsync(new GameUrlByLiveLobbyQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                PlayerCode: request.PlayerCode,
                IsMobileLogin: request.IsMobileLogin,
                BackUrl: request.BackUrl,
                Platform: AwcPlatforms.AWC_VENUS,
                BetLimit: request.BetLimit,
                Language: request.Language
                )).ConfigureAwait(false);

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceGameUrlReply> GameUrlByLottoLobbyByAwcAeLotto(GameInterfaceAwcServiceGameUrlByLottoLobbyRequest request, ServerCallContext context)
        {
            var result = await _gameUrlByLottoLobbyService.GetAsync(new GameUrlByLottoLobbyQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                PlayerCode: request.PlayerCode,
                IsMobileLogin: request.IsMobileLogin,
                BackUrl: request.BackUrl,
                Platform: AwcPlatforms.AWC_AELOTTO,
                Language: request.Language
                )).ConfigureAwait(false);

            return new GameInterfaceAwcServiceGameUrlReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                GameUrl = result.GameUrl
            };
        }

        public override async Task<GameInterfaceAwcServiceBalanceReply> GetBalance(GameInterfaceAwcServiceBalanceRequest request, ServerCallContext context)
        {
            var result = await _balanceService.GetAsync(new BalanceQuery(
                new(request.ApiUrl),
                request.AgentId,
                request.Cert,
                request.PlayerCode)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceBalanceReply()
            {
                Success = result.Success,
                Message = result.Message,
                IsPlayerExist = result.IsPlayerExist,
                Balance = result.Balance
            };
        }

        public override async Task<GameInterfaceAwcServiceReply> KickPlayer(GameInterfaceAwcServiceKickPlayerRequest request, ServerCallContext context)
        {
            await _logoutService.ExecuteAsync(new LogoutCommand(
                new(request.ApiUrl),
                request.AgentId,
                request.Cert,
                request.PlayerCode)).ConfigureAwait(false);

            return new GameInterfaceAwcServiceReply()
            {
                Success = true
            };
        }
    }
}
