
namespace ProjectFeudo.Domain.Interfaces.Services
{
    public interface ITimeService
    {
        bool HasTickedOneSecond(float currentFrameTime, float previousRecordedTime);
        bool HasTickedXSeconds(float currentFrameTime, float previousRecordedTime, int secondsAmout);
        bool HasTickedXSeconds(float currentFrameTime, float previousRecordedTime, int secondsAmout, float amountSecondsToTick);
    }
}


