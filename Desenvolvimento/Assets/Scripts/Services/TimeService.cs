using ProjectFeudo.Domain.Interfaces.Services;

public class TimeService : ITimeService
{
    public bool HasTickedOneSecond(float currentFrameTime, float previousRecordedTime) {

        return (currentFrameTime - previousRecordedTime) >= 1f; ;
    }

    public bool HasTickedXSeconds(float currentFrameTime, float previousRecordedTime, int secondsAmout) {
        return (currentFrameTime - previousRecordedTime) >= (1f * secondsAmout);
    }

    public bool HasTickedXSeconds(float currentFrameTime, float previousRecordedTime, int secondsAmout, float amountSecondsToTick) {
        return (currentFrameTime - previousRecordedTime) >= (amountSecondsToTick * secondsAmout);
    }
}
