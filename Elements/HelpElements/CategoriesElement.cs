using Launcher.Controls;
using LauncherNet._DataStatic;
using LauncherNet._Front;

namespace LauncherNet.Elements.HelpElements
{
  public class CategoriesElement
  {
    private int categoryLocationY;
    private List<string> helpCategories = new()
    {
      "Другое",
      "Приложения",
      "Категории",
      "Верхняя панель",
      "Горячие клавиши",
    };

    private List<string> helpHotKeys = new()
    {
      "<h>\"Горячие клавиши.\"",
      " ",
      " ",
      "\"F1\" - Вызов помощи программы.",
      " ",
      "\"Alt + F4(X)\" - Закрыть программу.",
      " ",
      "\"Ctrl + A\" - Добавить приложение в программу.",
      " ",
      "\"Ctrl + O\" - Открыть настройки программы.",
      " ",
      "\"Ctrl + \" - Пролистать панель с приложениями вниз.",
      " ",
      "\"Ctrl + \" - Пролистать панель с приложениями вверх.",
      " ",
      "\"Ctrl + 0\" - Создать новую категорию.",
      " ",
      "\"Ctrl + (1,2,...,9)\" - Открыть категорию под номером X.",
    };

    private List<string> helpTextCategory = new()
    {
      "<h>\"Создать новую категорию.\"",
      "Чтобы создать новую категорию в приложении, выполните следующие действия:",
      "1. Нажмите на элемент [ + ] на панели категорий, или нажмите комбинацию клавиш Ctrl + 0",
      "2. Заполните необходимые данные в появившемся окне",
      "3. Для сохраненения данных нажмите кнопку \"Применить\", в противном случае, нажмите кнопку \"Отмена\"",
      " ",
      " ",
      "<h>\"Переименовать категорию.\"",
      "Чтобы переименовать категорию в приложение, выполните следующие действия:",
      "1. Нажмите правой кнопкой мыши по нужной категории и выберите пункт \"Переименовать категорию\"",
      "2. Проверьте название категории в появившемся уведомлении",
      "3. Введите новое название категории",
      "3. Для сохраненения данных в программе нажмите кнопку \"Применить\", в противном случае, нажмите кнопку \"Отмена\"",
      " ",
      " ",
      "<h>\"Удалить категорию.\"",
      "Чтобы удалить новую категорию в приложение, выполните следующие действия:",
      "1. Нажмите правой кнопкой мыши по нужной категории. Откроется список функций. Выберите пункт \"Удалить категорию\"",
      "2. Проверьте название категории в появившемся уведомлении",
      "3. Для удаления данных их программы нажмите кнопку \"Ок\", в противном случае, нажмите кнопку \"Отмена\"",
      " ",
      " ",
      "<h>\"Добавить приложение.\"",
      "Чтобы добавить новое приложение в категорию, выполните следующие действия:",
      "1. Нажмите правой кнопкой мыши по нужной категории или нажмите сочетание клавиш Ctrl+A на клавиатуре.",
      "2. В появившемся окне проверьте имя категории, в которую хотите добавить приложение",
      "3. Чтобы не заполнять имя и путь файла, нажмите два раза по полю ввода пути к файлу. Выберите нужный файл",
      "4. Проверьте имя приложения. Если оно вам не подходит, то напишите имя вручную",
      "5. Вы можете добавить картинку приложения сами, нажав на кнопку \"Добавить изображение\" и выбрав путь к картинке.",
      "6. Если пункт 5 пропущен, то при нажатии на кнопку \"Применить\" перед вами появится новое окно",
      "7. Выберите походящее изображение и нажмите на кнопку \"Применить\"",
      "8. Приложение добавлено",
      " ",
      " ",
      "<h>\"Выбор категории.\"",
      "1. Ну тут всё просто, просто кликаем мышкой по нужной категории.",
      "2. Для людей, у которых отсутсвует мышка, есть продуманное сочетание клавиш Ctrl + \"Цифра от 1 до 9\". Но как вы можете заметить, больше чем 9 категорий вы открыть не сможете, да и у приложений данной фичи нет, так что купите мышку.",
      " ",
      " ",

    };
    private List<string> helpTextApp = new()
    {
      "<h>\"Открыть.\"",
      "Чтобы открыть приложение, вы можете использовать 2 варианта событий.",
      "1. Наведите на имя приложения, посмотрите как оно магическим образом поменялась на надпись \"Открыть\" и ткнуть на неё",
      "2. Наведите на имя приложения, посмотрите как оно магическим образом поменялась на надпись \"Открыть\", проигнорируйте данный ход событий, нажмите на правую кнопку мышки и выберите подпункт \"Открыть\"",
      " ",
      " ",
      "<h>\"Расположение файла.\"",
      "Чтобы открыть расположение файла, выполните следующие действия:",
      "1. Наведите на имя приложения",
      "2. Посмотрите как оно магическим образом поменялась на надпись \"Открыть\"",
      "3. Нажмите правой кнопкой мыши и выберите подпункт \"Расположение файла\"",
      " ",
      " ",
      "<h>\"Сменить обложку.\"",
      "Чтобы сменить обложку файла, выполните следующие действия:",
      "1. Наведите на имя приложения",
      "2. Посмотрите как оно магическим образом поменялась на надпись \"Открыть\"",
      "3. Нажмите правой кнопкой мыши и выберите подпункт \"Сменить обложку\"",
      "4. Введите путь к картинке вручную или нажмите два раза на поле ввода пути картинки",
      "5. Для сохраненения данных нажмите кнопку \"Применить\", в противном случае, нажмите кнопку \"Отмена\"",
      " ",
      " ",
      "<h>\"Удалить файл из лаунчера.\"",
      "Чтобы открыть расположение файла, выполните следующие действия:",
      "1. Наведите на имя приложения",
      "2. Посмотрите как оно магическим образом поменялась на надпись \"Открыть\"",
      "3. Нажмите правой кнопкой мыши и выберите подпункт \"Удалить файл из лаунчера\"",
      "4. Проверьте название приложения в появившемся уведомлении",
      "5. Для удаления данных нажмите кнопку \"Ок\", в противном случае, нажмите кнопку \"Отмена\"",
      " ",
      " ",
    };
    private List<string> helpTextTopPanel = new()
    {
      "<h>\"Сворачивание\" приложения",
      "Чтобы свернуть форму, нажмите на символ \"-\" в верхнем правом углу приложения.",
      " ",
      " ",
      "<h>\"Масштабируемость\" приложения",
      "1. Чтобы привести приложение к максимальному размеру из любого другого, нажмите на  \"⃞\" в верхнем правом углу приложения.",
      "2. Чтобы привести приложение к минимальному размеру из максимального, нажмите на   \"⃞\" в верхнем правом углу приложения.",
      " ",
      " ",
      "<h>\"Закрытие\" приложения",
      "1. Вы думали тут будет написано что-то типо \" Чтобы закрыть программу, нажмите на то-то то-то, там-то там-то\".",
      "На самом же деле, при нажатии на \"X\", программа закроется только в том случае, если вы удалили Иконку приложения. Если же иконка есть, то приложение свернётся в Tray. Это сделано для быстрого использования ПО. Вам не придётся каждый раз ждать загрузки приложения чтобы им воспользоваться.",
      " ",
      "Чтобы полностью закрыть приложение, вы можете выбрать один из 4 вариантов: ",
      " 1. Свернуть приложение в трэй и уже там выбрать подпункт \"Выход\"",
      " 2. Нажать комбинацию клавиш Alt+F4",
      " 3. Нажать комбинацию клавиш Alt+X",
      " 4. Завершить процесс через \"Диспетчер задач\"",
      " ",
      " ",
      "<h>\"Расположение\" приложения",
      "Чтобы перенести приложение в другое удобное место на экране, то наведите курсором мыши на верхнюю панель и зажмите её. Готово! Тащите куда хотите в пределах экрана",
      " ",
      " ",
    };
    private List<string> helpTextApplication = new()
    {
      "<h>\"Вызов помощи\"",
      "Чтобы вызвать данное окно, нажмите F1 на активном приложении.",
      " ",
      " ",
      "<h>\"Прокрутка приложений\"",
      "Если все ваши приложения не помещаются на экран, то вы можете прокрутить их с  помощью колёсика мыши или горячими клавишами Crtl + (⇡/⇣)",
      " ",
      " ",
      "<h>\"Изменение размеров.\"",
      "Наведите мышкой на одну из граней приложения (кроме верхней) и тяните в нужную вам сторону. Так же можно тянуть из нижних углов приложения.",
      " ",
      " ",
      "<h>\"Обновление приложения.\"",
      "Если что-то пошло не так с элементами на форме или ещё что-то то нажмите клавишу F5 чтобы починить это. Если вам это не помогло, то перезагрузите приложение. Если и это не помогло, то я не знаю что вам сказать...",
      " ",
      " ",
    };



    public Panel? CreateCategoriesElement()
    {
      if (DataHelpForm.helpForm != null)
      {
        Panel categoriesElement = new()
        {
          Width = 150,
          BorderStyle = BorderStyle.None,
        };
        if (DataHelpForm.topElement != null)
        {
          categoriesElement.Height = DataHelpForm.helpForm.Height - DataHelpForm.topElement.Height;
          categoriesElement.Location = new Point(0, DataHelpForm.topElement.Height);
        }
        else
        {
          categoriesElement.Height = DataHelpForm.helpForm.Height;
          categoriesElement.Location = new Point(0, 0);
        }

        for (int i = 0; i < helpCategories.Count; i++)
        {
          categoriesElement.Controls.Add(CreateHelpElement(categoriesElement, i));
        }

        return categoriesElement;
      }
      return null;
    }

    /// <summary>
    /// Возвращает элемент выбора помощи.
    /// </summary>
    /// <param name="categoriesElement"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private TextControl CreateHelpElement(Panel categoriesElement, int index)
    {
      TextControl categoryElement = new()
      {
        Text = helpCategories[index],
        Width = categoriesElement.Width,
        Height = 50,
        Location = new(0, categoryLocationY),
      };

      CreateHelpMain(categoryElement, helpHotKeys);

      categoryElement.MouseDown += (s, a) =>
      {
        if (DataHelpForm.mainElement != null)
          DataHelpForm.helpForm?.Controls.Remove(DataHelpForm.mainElement);

        if (categoryElement.Text == helpCategories[2])
          CreateHelpMain(categoryElement, helpTextCategory);

        else if (categoryElement.Text == helpCategories[1])
          CreateHelpMain(categoryElement, helpTextApp);

        else if (categoryElement.Text == helpCategories[3])
          CreateHelpMain(categoryElement, helpTextTopPanel);

        else if (categoryElement.Text == helpCategories[0])
          CreateHelpMain(categoryElement, helpTextApplication);

        else if (categoryElement.Text == helpCategories[4])
          CreateHelpMain(categoryElement, helpHotKeys);

        else
          CreateHelpMain(categoryElement, null);
      };

      categoryLocationY += categoriesElement.Height;
      DataHelpForm.categoriesElement = categoriesElement;

      return categoryElement;
    }

    private void CreateHelpMain(TextControl categoryElement, List<string>? content)
    {
      if (DataHelpForm.helpForm != null)
      {
        int locationY = 0;
        Panel mainElement = new()
        {
          Visible = true,
          Height = categoryElement.Height,
          Width = DataHelpForm.helpForm.Width - categoryElement.Width,
          AutoScroll = true,
        };
        if (DataHelpForm.topElement != null)
        {
          mainElement.Location = new(categoryElement.Width, DataHelpForm.topElement.Height);
        }
        else
        {
          mainElement.Location = new(categoryElement.Width, 0);
        }

        Label labelHeader = new Label()
        {
          Width = mainElement.Width,
          Location = new(10, locationY),
          ForeColor = Color.FromArgb(255 - mainElement.BackColor.R, 255 - mainElement.BackColor.G, 255 - mainElement.BackColor.B),
          Font = new Font(mainElement.Font.FontFamily, 15),
          Text = categoryElement.Text,
          //BorderStyle = BorderStyle.FixedSingle,
        };
        labelHeader.Width = TextRenderer.MeasureText(labelHeader.Text, labelHeader.Font).Width * 2;
        labelHeader.Height = TextRenderer.MeasureText(labelHeader.Text, labelHeader.Font).Height;
        if (content == null)
        {
          labelHeader.Text = $"Раздел помощи \"{labelHeader.Text}\" отсутствует(";
        }
        else if (content[0].Contains("Горячие клавиши"))
        {
          mainElement.Visible = true;
        }
        locationY += (labelHeader.Height + labelHeader.Location.Y + 20);


        if (DataHelpForm.topElement != null)
        {
          mainElement.Height = DataHelpForm.helpForm.Height - DataHelpForm.topElement.Height;
        }
        else
        {
          mainElement.Height = DataHelpForm.helpForm.Height;
        }


        mainElement.Controls.Add(labelHeader);

        if (content != null)
        {

          for (int i = 0; i < content.Count; i++)
          {
            Font font = new Font(mainElement.Font.FontFamily, 10);
            int width = TextRenderer.MeasureText(content[i], font).Width;
            int newWidth = width;
            int height = TextRenderer.MeasureText(content[i], font).Height;
            int newHeight = height;

            string tag = "Text";
            string textInfo = content[i];
            string key = "<h>";
            if (content[i].Contains(key))
            {
              textInfo = content[i].Substring(key.Length, content[i].Length - key.Length);
              font = new Font(mainElement.Font.FontFamily, 13);
              tag = "Subtitle";
            }

            while (newWidth > mainElement.Width)
            {
              newHeight += height;
              newWidth -= mainElement.Width;
            }
            width = mainElement.Width - 32;

            TextControl label = new TextControl()
            {
              Dock = DockStyle.None,
              Text = textInfo,
              Width = width,
              Height = newHeight,
              Location = new(5, locationY),
              Font = font,
              Tag = tag,
            };
            locationY += label.Height;
            mainElement.Controls.Add(label);
          }
          new DesignHelpForm().DesignMainElementHelpForm(mainElement);
        }


        DataHelpForm.mainElement = mainElement;
        DataHelpForm.helpForm.Controls.Add(mainElement);
      }
    }
  }
}
