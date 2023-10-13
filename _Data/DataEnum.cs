namespace LauncherNet._Data
{
  public static class DataEnum
  {
    /// <summary>
    /// Функции категорий.
    /// </summary>
    public enum FunctionCategory
    {
      /// <summary>
      /// Добавление приложения в категорию.
      /// </summary>
      AddApp,

      /// <summary>
      /// Добавление категории в лаунчер.
      /// </summary>
      AddCategory,

      /// <summary>
      /// Удаление категории из лаунчера.
      /// </summary>
      DeleteCategory,

      /// <summary>
      /// Переименование категории в лаунчере.
      /// </summary>
      RenameCategory,
    }

    /// <summary>
    /// Функции приложений.
    /// </summary>
    public enum FunctionApp
    {

      /// <summary>
      /// Открыть приложение.
      /// </summary>
      Open,

      /// <summary>
      /// Открыть расположение файла.
      /// </summary>
      PathFile,

      /// <summary>
      /// Смена картинки приложения.
      /// </summary>
      ChangeImage,

      /// <summary>
      /// Удалить из лаунчера.
      /// </summary>
      Delete
    }

    /// <summary>
    /// Список возможных "прилипаний" формы к границам экрана.
    /// </summary>
    public enum Sticking
    {
      /// <summary>
      /// Левая граница экрана.
      /// </summary>
      Left,

      /// <summary>
      /// Правая граница экрана.
      /// </summary>
      Right,

      /// <summary>
      /// Верхняя граница экрана.
      /// </summary>
      Top,

      /// <summary>
      /// Нижняя граница экрана.
      /// </summary>
      Bottom,

      /// <summary>
      /// Не прилипает к границе экрана.
      /// </summary>
      Nope
    }

    /// <summary>
    /// Список возможных границ изменений формы.
    /// </summary>
    public enum Expand
    {
      /// <summary>
      /// Левая граница формы.
      /// </summary>
      Left,

      /// <summary>
      /// Правая граница формы.
      /// </summary>
      Right,

      /// <summary>
      /// НИжняя граница формы.
      /// </summary>
      Bottom,

      /// <summary>
      /// Левая нижняя граница формы.
      /// </summary>
      LeftBottom,

      /// <summary>
      /// Правая нижняяя граница формы.
      /// </summary>
      RightBottom,

      /// <summary>
      /// Никакая из перечисленных граница формы.
      /// </summary>
      Nope
    }

    /// <summary>
    /// Цвета лаунчера.
    /// </summary>
    public enum ColorLauncher
    {
      FirstMainColor,
      FirstAdditionColor,
      SecondMainColor,
      SecondAdditionColor
    }

  }
}
