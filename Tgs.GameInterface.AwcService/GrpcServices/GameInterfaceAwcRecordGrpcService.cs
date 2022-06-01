using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices
{
    public class GameInterfaceAwcRecordGrpcService : GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceBase
    {
        private readonly IQueryService<GameSettleTransactionQuery, GameSettleTransactionResult> _gameSettleTransactionService;
        private readonly IQueryService<GameTransactionQuery, GameTransactionResult> _gameTransactionService;
        private readonly IQueryService<GameUnsettleTransactionQuery, GameUnsettleTransactionResult> _gameUnsettleTransactionService;

        public GameInterfaceAwcRecordGrpcService(
            IQueryService<GameSettleTransactionQuery, GameSettleTransactionResult> gameSettleTransactionService,
            IQueryService<GameUnsettleTransactionQuery, GameUnsettleTransactionResult> gameUnsettleTransactionService,
            IQueryService<GameTransactionQuery, GameTransactionResult> gameTransactionService)
        {
            _gameSettleTransactionService = gameSettleTransactionService ?? throw new ArgumentNullException(nameof(gameSettleTransactionService));
            _gameUnsettleTransactionService = gameUnsettleTransactionService ?? throw new ArgumentNullException(nameof(gameUnsettleTransactionService));
            _gameTransactionService = gameTransactionService ?? throw new ArgumentNullException(nameof(gameTransactionService));
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcAeLotto(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AELOTTO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcAws(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AWS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcCockfight(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_COCKFIGHT,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcFacai(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FACAI,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcFs(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcKm(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_KM,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcLudo(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_LUDO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcPgs(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_PGS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcRcb(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_RCB,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcSpade(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_SPADE,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcVenus(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_VENUS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameSettleTransactionReply> GameSettleByAwcYl(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
        {
            var result = await _gameSettleTransactionService.QueryAsync(new GameSettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_YL,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameSettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameSettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    TxStatus = transaction.TxStatus,
                    SettleStatus = transaction.SettleStatus,
                    BetTime = transaction.BetTime,
                    TxTime = transaction.TxTime,
                    UpdateTime = transaction.UpdateTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    Turnover = transaction.Turnover,
                    WinAmount = transaction.WinAmount,
                    RealWinAmount = transaction.RealWinAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    JackpotWinAmount = transaction.JackpotWinAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameUnsettleTransactionReply> GameUnsettleByAwcAeLotto(GameInterfaceAwcServiceGameUnsettleRequest request, ServerCallContext context)
        {
            var result = await _gameUnsettleTransactionService.QueryAsync(new GameUnsettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AELOTTO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameUnsettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameUnsettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    BetTime = transaction.BetTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameUnsettleTransactionReply> GameUnsettleByAwcCockfight(GameInterfaceAwcServiceCockFightGameUnsettleRequest request, ServerCallContext context)
        {
            var result = await _gameTransactionService.QueryAsync(new GameTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_COCKFIGHT,
                TimeFrom: request.TimeFrom.ToDateTimeOffset(),
                TransactionStatus: Core.TransactionStatus.Bet)).ToListAsync().ConfigureAwait(false);

            var reply = new GameUnsettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameUnsettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    BetTime = transaction.BetTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }

        public override async Task<GameUnsettleTransactionReply> GameUnsettleByAwcRcb(GameInterfaceAwcServiceGameUnsettleRequest request, ServerCallContext context)
        {
            var result = await _gameUnsettleTransactionService.QueryAsync(new GameUnsettleTransactionQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_RCB,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

            var reply = new GameUnsettleTransactionReply();

            result.ForEach(transaction =>
            {
                reply.Items.Add(new GameUnsettleTransaction()
                {
                    ExternalRoundId = transaction.ExternalRoundId,
                    Platform = transaction.Platform,
                    PlatformTxId = transaction.PlatformTxId,
                    GameType = transaction.GameType,
                    GameCode = transaction.GameCode,
                    GameName = transaction.GameName,
                    RoundId = transaction.RoundId,
                    UserId = transaction.UserId,
                    Currency = transaction.Currency,
                    BetTime = transaction.BetTime,
                    BetType = transaction.BetType,
                    BetAmount = transaction.BetAmount,
                    RealBetAmount = transaction.RealBetAmount,
                    JackpotBetAmount = transaction.JackpotBetAmount,
                    GameInfo = transaction.GameInfo,
                });
            });

            return reply;
        }
    }
}
