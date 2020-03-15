
namespace SceneManagament.Examples
{
    public class ExamplePlatformScene : PlatformScene<SceneController>
    {
        private const string IOS_EXAMPLE = "IosScene";
        private const string ANDROID_EXAMPLE = "AndroidExample";
        private const string WindowsExample = "WindowsExample";
        private const string Default = "DefaultExample";

        protected override string AndroidSceneName => ANDROID_EXAMPLE;
        protected override string IosSceneName => IOS_EXAMPLE;
        protected override string DefaultSceneName => Default;
        protected override string WindowsSceneName => WindowsExample;
    }
}
