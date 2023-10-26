using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices;

public class GameInterfaceAwcRecordGrpcService : GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceBase
{
    private readonly IQueryService<GameRecordPullQuery, GameRecordPullResult> _gameRecordPullService;
    private readonly IQueryService<GameRecordSettledQuery, GameRecordSettledResult> _gameRecordSettledService;
    private readonly IQueryService<OutstandingByBetTimeQuery, OutstandingByBetTimeResult> _outstandingByBetTimeService;
    private readonly IQueryService<TransactionByUpdateDateByStatusQuery, GameRecordPullResult> _transactionByUpdateDateByStatusService;

    public GameInterfaceAwcRecordGrpcService(
        IQueryService<GameRecordSettledQuery, GameRecordSettledResult> gameRecordSettledService,
        IQueryService<OutstandingByBetTimeQuery, OutstandingByBetTimeResult> outstandingByBetTimeService,
        IQueryService<GameRecordPullQuery, GameRecordPullResult> gameRecordPullService,
        IQueryService<TransactionByUpdateDateByStatusQuery, GameRecordPullResult> transactionByUpdateDateByStatusService)
    {
        _gameRecordSettledService = gameRecordSettledService ?? throw new ArgumentNullException(nameof(gameRecordSettledService));
        _outstandingByBetTimeService = outstandingByBetTimeService ?? throw new ArgumentNullException(nameof(outstandingByBetTimeService));
        _gameRecordPullService = gameRecordPullService ?? throw new ArgumentNullException(nameof(gameRecordPullService));
        _transactionByUpdateDateByStatusService = transactionByUpdateDateByStatusService ?? throw new ArgumentNullException(nameof(transactionByUpdateDateByStatusService));
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcAeLotto(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AELOTTO,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcAws(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AWS,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken
            )
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcCockfight(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_COCKFIGHT,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcFacai(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FACAI,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcFs(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FS,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcKm(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_KM,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcLudo(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_LUDO,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcPgs(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_PGS,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcRcb(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_RCB,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcSg(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_SG,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcSpade(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_SPADE,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcVenus(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_VENUS,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GamePullRecordReply> GamePullRecordByAwcYl(GamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _gameRecordPullService
            .QueryAsync(
            query: new GameRecordPullQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_YL,
                TimeFrom: request.TimeFrom.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GamePullRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GamePullRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcAeLotto(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AELOTTO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcAws(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AWS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcCockfight(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_COCKFIGHT,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcFacai(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FACAI,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcFs(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_FS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcKm(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_KM,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcLudo(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_LUDO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcPgs(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_PGS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcRcb(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_RCB,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcSg(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_SG,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcSpade(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_SPADE,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcVenus(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_VENUS,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameSettleRecordReply> GameSettleByAwcYl(GameSettleRequest request, ServerCallContext context)
    {
        var result = await _gameRecordSettledService
            .QueryAsync(
            query: new GameRecordSettledQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_YL,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

        var reply = new GameSettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameSettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameUnsettleRecordReply> GameUnsettleByAwcAeLotto(GameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _outstandingByBetTimeService
            .QueryAsync(
            query: new OutstandingByBetTimeQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_AELOTTO,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<OutstandingByBetTimeResult>();

        var reply = new GameUnsettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameUnsettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameUnsettleRecordReply> GameUnsettleByAwcCockfight(CockFightGameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateByStatusService
            .QueryAsync(
            new TransactionByUpdateDateByStatusQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_COCKFIGHT,
                TimeFrom: request.TimeFrom.ToDateTimeOffset(),
                TransactionStatus: TransactionStatus.Bet),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

        var reply = new GameUnsettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameUnsettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }

    public override async Task<GameUnsettleRecordReply> GameUnsettleByAwcRcb(GameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _outstandingByBetTimeService
            .QueryAsync(
            new OutstandingByBetTimeQuery(
                ApiUrl: new(request.ApiUrl),
                AgentId: request.AgentId,
                Cert: request.Cert,
                Platform: AwcPlatforms.AWC_RCB,
                StartTime: request.StartTime.ToDateTimeOffset(),
                EndTime: request.EndTime.ToDateTimeOffset()),
            cancellationToken: context.CancellationToken)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<OutstandingByBetTimeResult>();

        var reply = new GameUnsettleRecordReply();

        if (result.Any())
        {
            foreach (var transaction in result)
            {
                reply.Items.Add(new GameUnsettleRecord()
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
                    GameInfo = transaction.GameInfo
                });
            };
        }

        return reply;
    }
}
