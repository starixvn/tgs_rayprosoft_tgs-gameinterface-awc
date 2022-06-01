namespace Tgs.GameInterface.AwcService.Core
{
    public static class DateTimeOffsetExtensions
    {
        public static string ToIso8601String(this DateTimeOffset dateTimeOffset, bool containMillisecond = false)
        {
            // Returns string format like as below:
            // contain millisecond: 2020-09-25T07:07:31.329+00:00
            // no millisecond: 2020-09-25T07:07:31+00:00

            var format = containMillisecond ? @"yyyy-MM-dd\THH:mm:ss.fffK" : @"yyyy-MM-dd\THH:mm:ssK";
            return dateTimeOffset.ToString(format);
        }
    }
}
