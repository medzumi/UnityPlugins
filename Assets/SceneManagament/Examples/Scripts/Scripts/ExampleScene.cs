
namespace SceneManagament.Examples
{
    public class ExampleScene: Scene<SceneController>
    {
        private const string SCENE_NAME = "DefaultScene";

        protected override string SceneId => SCENE_NAME;
    }
}