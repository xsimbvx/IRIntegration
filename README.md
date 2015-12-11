# IRIntegration
Данная программа является примером интеграции библиотеки восстановления смазанных и расфокусированных изображений.


## Описание
Программа была разработана как часть дипломной работы. Она включает в себя ещё три части: 
[Легковесная библиотека для работы с изображениями на .NET](https://github.com/Kovnir/ImageEditor), 
[Библиотека восстановления расфокуссированных изображений](https://github.com/xsimbvx/ImageRecovery), [Модифицированный алгоритм восстановления изображений](https://github.com/Kovnir/DeblurModification). 
Проект был собран в Microsoft Visual Studio 2015.

## Классы
Название | Описание
------------ | -------------
Program.cs | Точка входа в программу
Form1.cs | Основная и единствнная форма программы

Окно программы содержи 4 области:
* исходное изображение;
* смазанное изображение;
* зашумленное изображение;
* восстановленное изображение.

В каждой из 4-ех областей имеется:
* кнопка, по нажатию на которую выполняется преобразование изображения;
* изображение, соотетствующее названию области;
* текстовое поле, включающее в себя размер изображения;
* дополнительная информация.

Под дополнительной информацией подразумевается маска искажающего оператора для искаженного изображения, маска аддитивного шума для зашумленного и фильтр восстановления для восстановленного изображения.

По нажатию на любую кнопку выполняется преобразование изображения из предыдущего, с занесением результата в поля текущего этапа

## Пример работы

![Пример](https://github.com/xsimbvx/IRIntegration/blob/master/Images/Example_01.JPG "Example 1")

По нажатию на кнопку "Загрузка" происходит загрузка изображения, если изображение уже выбрано, то загружается новое. Также загрузить изображение можно кликнув на pictureBox расположенный под кнопкой "Загрузка". Сразу после загрузки изображения все последующие шаги сбросятся в исходное положение.

По нажатию на кнопку "3х3" или "5х5" происходит Гауссово размытие маской 3х3 и 5х5 соответственно.

Текстовое поле возле кнопки "Добавить" предназначено для задания величины (где 1.0 = 100%) добавляемого аддитивного шума. По умолчанию значение равно нулю. По нажатию кнопки происходит добавление шума.

По нажатию кнопки "Инверсная фильтрация" выполняется реконструкция смазанного изображения с помощью инверсного фильтра.

Каждый последующий шаг невозможноы выполнить, если данные предыдущего шага не готовы. Т.е. добавление шума возможно только лишь в случае, если выполнено размытие и загружена картинка и т.п. Но если картинка не загружена, а пользователь нажимает на кнопку добавления размытия, то откроется окно выбора изображения, после его выбора выполнится размытие.
