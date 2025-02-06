using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Update
{
    public partial class Form1 : Form
    {
        //private SortedList itemDescriptions;
        private SortedList itemDescriptions = new SortedList();

        private string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "item_ext_desc.txt");

        public Form1()
        {
            InitializeComponent();
            // Adiciona as linguagens no comboBox_Language
            comboBox_Language.Items.Add("Escolha o idioma aqui");
            comboBox_Language.Items.Add("Brasilian");
            comboBox_Language.Items.Add("English");
            comboBox_Language.Items.Add("Russian");
            comboBox_Language.Items.Add("Traditional Chinese");

            // Define o item padrão selecionado
            comboBox_Language.SelectedIndex = 0;

            // Define o evento de alteração de seleção
            comboBox_Language.SelectedIndexChanged += comboBox_Language_SelectedIndexChanged;
        }

        private void button_autoDetect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            if (comboBox_dbSource.SelectedIndex < 1)
            {
                string description = itemDescriptions[numericUpDown_itemID.Value.ToString()] as string;
                if (!string.IsNullOrEmpty(description))
                {
                    description = description.Replace("\\r", " \\r");
                    textBox_description.Text = description;
                }
                else
                {
                    MessageBox.Show("ID not found in database.");
                }
            }
            else
            {
                try
                {
                    int index;
                    int length;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www." + comboBox_dbSource.SelectedItem.ToString() + "/items/" + numericUpDown_itemID.Value.ToString());
                    request.Proxy = null;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader wr = new StreamReader(response.GetResponseStream()))
                    {
                        string content = wr.ReadToEnd();
                        wr.Close();

                        // Find Item Name
                        index = content.IndexOf("<th class=\"itemHeader\"") + 35;
                        if (index > 34)
                        {
                            length = content.IndexOf("<a href", index) - index;
                            string name = content.Substring(index, length);
                            // Remove span + color
                            if (name.Contains("<"))
                            {
                                name = name.Substring(name.IndexOf(">") + 1);
                                name = name.Substring(0, name.IndexOf("</"));
                            }
                            name = name.Replace("&#9734;", "★");
                            textBox_name.Text = name;
                        }

                        // Find if Item Contains Shop Info
                        index = content.IndexOf("<a href=\"shopitem/", index) + 18;

                        if (index > 18)
                        {
                            length = content.IndexOf("\">", index) - index;
                            string shop_id = content.Substring(index, length);

                            // Load Shop Description
                            request = (HttpWebRequest)WebRequest.Create("https://www." + comboBox_dbSource.SelectedItem.ToString() + "/shopitem/" + shop_id);
                            request.Proxy = null;
                            response = (HttpWebResponse)request.GetResponse();
                            using (StreamReader shopWr = new StreamReader(response.GetResponseStream()))
                            {
                                content = shopWr.ReadToEnd();
                                shopWr.Close();

                                index = content.IndexOf("<h3>Description</h3><p>") + 23;
                                if (index > 22)
                                {
                                    length = content.IndexOf("</p>", index) - index;
                                    string description = content.Substring(index, length);

                                    description = description.Replace("<span style='color:", "");
                                    description = description.Replace("#", "^");
                                    description = description.Replace(";", "");
                                    description = description.Replace("'>", "");
                                    description = description.Replace("<br />", "\\r");
                                    description = description.Replace("<br/>", "\\r");
                                    description = description.Replace("<br>", "\\r");
                                    description = description.Replace("</span>", "");
                                    description = description.Replace("\\r", " \\r");

                                    textBox_description.Text = description;
                                }
                            }
                        }
                    }
                    Cursor = Cursors.Default;
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection Failed!");
                    Cursor = Cursors.Default;
                }
            }
        }

        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_Language.SelectedItem.ToString())
            {
                case "Brasilian":
                    richTextBox1.Text = "A primeira parte do código inclui uma série de diretivas \"using\" que importam os namespaces necessários para o funcionamento do programa. Isso permite que o código utilize classes e funcionalidades de diferentes bibliotecas.\r\n\r\nO código está contido no namespace \"Update\". Ele define uma classe chamada \"Form1\" que herda da classe \"Form\". Isso sugere que esta classe representa um formulário da interface gráfica do Windows Forms.\r\n\r\nDentro da classe \"Form1\", há uma variável privada chamada \"itemDescriptions\" que é do tipo \"SortedList\" (uma coleção ordenada) e outra variável privada chamada \"directoryPath\", que armazena um caminho de diretório para um arquivo chamado \"item_ext_desc.txt\".\r\n\r\nO construtor \"Form1()\" é definido. Esse é o construtor do formulário e é chamado quando uma instância desse formulário é criada. Ele chama o método \"InitializeComponent()\" e configura a interface gráfica do formulário.\r\n\r\nA próxima parte importante do código é o método chamado \"button_autoDetect_Click\", que é um manipulador de evento associado ao clique no botão com o nome \"button_autoDetect\". Isso sugere que este método será executado quando o botão for clicado.\r\n\r\nDentro desse método, o cursor do mouse é alterado para o indicador de \"AppStarting\", indicando que o aplicativo está realizando uma tarefa que requer algum tempo para ser concluída.\r\n\r\nA condição if (comboBox_dbSource.SelectedIndex < 1) verifica se um item foi selecionado em um ComboBox com o nome \"comboBox_dbSource\". Se o índice selecionado for menor que 1, o código entra nesse bloco. Essa parte do código parece tratar de uma opção relacionada a uma base de dados local.\r\n\r\nDentro desse bloco, o código tenta obter uma descrição de item da coleção \"itemDescriptions\" com base no valor do \"numericUpDown_itemID\". Se a descrição não for vazia, ela é manipulada para substituir caracteres de nova linha (\"\\r\") por \" \\r\" (aparentemente para formatação).\r\n\r\nSe o índice selecionado no ComboBox for maior ou igual a 1, isso indica que a opção de base de dados externa foi selecionada. Nesse caso, o código tenta obter informações da web.\r\n\r\nUma requisição HTTP é criada para uma URL baseada em informações do ComboBox e do \"numericUpDown_itemID\". Isso sugere que o código está tentando acessar informações de um item online.\r\n\r\nO código faz uma solicitação à URL e obtém uma resposta HTTP. Em seguida, lê o conteúdo da resposta.\r\n\r\nO código procura por uma tag HTML específica (\"<th class=\"itemHeader\"\") no conteúdo da resposta para extrair o nome do item. Ele manipula a string para extrair o nome do item, removendo partes desnecessárias.\r\n\r\nO código também procura por outra tag HTML (\"<a href=\"shopitem/\") no conteúdo da resposta para determinar se o item possui informações de loja associadas.\r\n\r\nSe informações de loja estiverem associadas ao item, o código faz outra requisição HTTP para obter as informações detalhadas da loja.\r\n\r\nO código procura por uma tag HTML específica (\"<h3>Description</h3><p>\") nas informações da loja para extrair a descrição da loja. A descrição é manipulada para remover partes desnecessárias e formatá-la.\r\n\r\nFinalmente, a descrição do item ou da loja é exibida no TextBox correspondente.\r\n\r\nSe ocorrer algum erro durante todo esse processo, uma caixa de mensagem de erro \"Connection Failed!\" é exibida.\r\n\r\nLembrando que este é um trecho de código de um aplicativo Windows Forms que interage com informações da web e atualiza a interface gráfica com as informações obtidas.\r\n---------------------------------------------------------------------------------------------------------------------------------------\r\nDESCRIPTION\r\n---------------------------\r\nPrimeiro, o código verifica se a opção selecionada no comboBox_dbSource é menor que 1, o que sugere que o item é de uma fonte local (itens pré-carregados) em vez de uma fonte de banco de dados online.\r\n\r\nSe a opção selecionada for menor que 1, o código procura a descrição associada ao item, usando o valor do numericUpDown_itemID como chave no dicionário itemDescriptions. Se uma descrição válida for encontrada, ela é processada para substituir caracteres especiais e, em seguida, a caixa de texto textBox_description é preenchida com a descrição processada.\r\n\r\nSe a opção selecionada for maior ou igual a 1, o código tenta obter informações sobre o item de um site online. Ele envia uma solicitação HTTP para uma URL específica, baseada na fonte selecionada e no ID do item.\r\n\r\nO código analisa o conteúdo da resposta HTML para extrair informações, como o nome do item e a descrição. Ele faz isso procurando por elementos HTML específicos nas páginas web.\r\n\r\nA descrição é extraída da resposta HTML, e em seguida, é feito um processamento semelhante ao feito no primeiro cenário para remover elementos HTML, substituir caracteres especiais, como cores representadas em códigos hexadecimais, e substituir quebras de linha por caracteres especiais (\\\\r).\r\n\r\nA descrição processada é então definida como o texto da caixa de texto textBox_description.\r\n\r\nSe ocorrer um erro durante o processo, uma mensagem de erro é exibida em uma caixa de diálogo.\r\n\r\nEm resumo, esse trecho de código parece preencher a caixa de texto textBox_description com a descrição de um item, que pode ser obtida de uma fonte local ou de um site online, dependendo das opções selecionadas. Ele também realiza algum processamento para garantir que o texto exibido seja formatado corretamente.\r\n";
                    break;

                case "English":
                    richTextBox1.Text = "The first part of the code includes a series of \"using\" directives that import the namespaces needed for the program to work. This allows the code to use classes and functionality from different libraries.\r\n\r\nThe code is contained in the \"Update\" namespace. It defines a class called \"Form1\" that inherits from the \"Form\" class. This suggests that this class represents a Windows Forms graphical interface form.\r\n\r\nWithin the \"Form1\" class, there is a private variable called \"itemDescriptions\" that is of type \"SortedList\" (an ordered collection) and another private variable called \"directoryPath\" that stores a directory path to a file called \"item_ext_desc.txt\".\r\n\r\nThe \"Form1()\" constructor is defined. This is the constructor of the form and is called when an instance of this form is created. It calls the \"InitializeComponent()\" method and sets up the graphical interface of the form.\r\n\r\nThe next important part of the code is the method called \"button_autoDetect_Click\", which is an event handler associated with the click of the button named \"button_autoDetect\". This suggests that this method will be executed when the button is clicked.\r\n\r\nInside this method, the mouse cursor changes to the \"AppStarting\" indicator, indicating that the application is performing a task that requires some time to complete.\r\n\r\nThe if (comboBox_dbSource.SelectedIndex < 1) condition checks whether an item has been selected in a ComboBox named \"comboBox_dbSource\". If the selected index is less than 1, the code enters this block. This part of the code appears to be dealing with an option related to a local database.\r\n\r\nInside this block, the code attempts to get an item description from the \"itemDescriptions\" collection based on the value of \"numericUpDown_itemID\". If the description is not empty, it is manipulated to replace newline characters (\"\\r\") with \" \\r\" (apparently for formatting).\r\n\r\nIf the selected index in the ComboBox is greater than or equal to 1, this indicates that the external database option has been selected. In this case, the code attempts to retrieve information from the web.\r\n\r\nAn HTTP request is made to a URL based on information from the ComboBox and the \"numericUpDown_itemID\". This suggests that the code is trying to access information about an item online.\r\n\r\nThe code makes a request to the URL and gets an HTTP response. It then reads the response content.\r\n\r\nThe code looks for a specific HTML tag (\"<th class=\"itemHeader\"\") in the response content to extract the item name. It manipulates the string to extract the item name, removing unnecessary parts.\r\n\r\nThe code also looks for another HTML tag (\"<a href=\"shopitem/\") in the response content to determine if the item has associated store information.\r\n\r\nIf store information is associated with the item, the code makes another HTTP request to get the detailed store information.\r\n\r\nThe code looks for a specific HTML tag (\"<h3>Description</h3><p>\") in the store information to extract the store description. The description is manipulated to remove unnecessary parts and format it.\r\n\r\nFinally, the item or store description is displayed in the corresponding TextBox.\r\n\r\nIf any error occurs during this entire process, a \"Connection Failed!\" error message box is displayed.\r\n\r\nRemember that this is a code snippet from a Windows Forms application that interacts with information from the web and updates the graphical interface with the obtained information.\r\n\r\n--------------------------------------------------------------------------------------------------------------------------------------\r\nDESCRIPTION\r\n--------------------------\r\nFirst, the code checks if the option selected in the comboBox_dbSource is less than 1, which suggests that the item is from a local source (preloaded items) rather than an online database source.\r\n\r\nIf the selected option is less than 1, the code looks up the description associated with the item, using the value of numericUpDown_itemID as the key in the itemDescriptions dictionary. If a valid description is found, it is processed to replace special characters, and then the textBox_description text box is populated with the processed description.\r\n\r\nIf the selected option is greater than or equal to 1, the code attempts to get information about the item from an online website. It sends an HTTP request to a specific URL, based on the selected source and the item ID.\r\n\r\nThe code parses the content of the HTML response to extract information, such as the item name and description. It does this by looking for specific HTML elements on web pages.\r\n\r\nThe description is extracted from the HTML response, and then similar processing is done as in the first scenario to remove HTML elements, replace special characters such as colors represented in hexadecimal codes, and replace line breaks with special characters (\\\\r).\r\n\r\nThe processed description is then set as the text of the textBox_description text box.\r\n\r\nIf an error occurs during the process, an error message is displayed in a dialog box.\r\n\r\nIn summary, this code snippet appears to populate the textBox_description text box with the description of an item, which can be obtained from a local source or an online website, depending on the options selected. It also performs some processing to ensure that the displayed text is formatted correctly.";
                    break;

                case "Russian":
                    richTextBox1.Text = "Первая часть кода включает в себя ряд директив «using», которые импортируют пространства имен, необходимые для функционирования программы. Это позволяет коду использовать классы и функции из разных библиотек.\r\n\r\nКод содержится в пространстве имен «Обновление». Он определяет класс с именем «Form1», который наследуется от класса «Form». Это говорит о том, что данный класс представляет собой форму графического интерфейса Windows Forms.\r\n\r\nВнутри класса «Form1» есть частная переменная «itemDescriptions», которая имеет тип «SortedList» (упорядоченная коллекция), и еще одна частная переменная «directoryPath», которая хранит путь к каталогу с файлом «item_ext_desc.txt».\r\n\r\nОпределен конструктор «Form1()». Это конструктор формы, который вызывается при создании экземпляра этой формы. Он вызывает метод «InitializeComponent()» и настраивает графический интерфейс формы.\r\n\r\nСледующая важная часть кода — метод «button_autoDetect_Click», который представляет собой обработчик событий, связанный с нажатием кнопки «button_autoDetect». Это говорит о том, что данный метод будет выполнен при нажатии кнопки.\r\n\r\nВ рамках этого метода курсор мыши меняется на индикатор «AppStarting», указывающий на то, что приложение выполняет задачу, для завершения которой требуется некоторое время.\r\n\r\nУсловие if (comboBox_dbSource.SelectedIndex < 1) проверяет, выбран ли элемент в ComboBox с именем «comboBox_dbSource». Если выбранный индекс меньше 1, код входит в этот блок. Эта часть кода, по-видимому, имеет дело с опцией, связанной с локальной базой данных.\r\n\r\nВнутри этого блока код пытается получить описание элемента из коллекции «itemDescriptions» на основе значения «numericUpDown_itemID». Если описание непустое, оно обрабатывается с целью замены символов новой строки (\"\\r\") на \" \\r\" (очевидно, для форматирования).\r\n\r\nЕсли индекс, выбранный в ComboBox, больше или равен 1, это означает, что выбран вариант внешней базы данных. В этом случае код пытается получить информацию из Интернета.\r\n\r\nHTTP-запрос создается для URL-адреса на основе информации из ComboBox и «numericUpDown_itemID». Это говорит о том, что код пытается получить доступ к информации из онлайн-элемента.\r\n\r\nКод отправляет запрос на URL и получает HTTP-ответ. Затем прочитайте содержание ответа.\r\n\r\nКод ищет определенный HTML-тег («<th class=\"itemHeader\"») в содержимом ответа для извлечения имени элемента. Он обрабатывает строку, чтобы извлечь имя элемента, удаляя ненужные части.\r\n\r\nКод также ищет другой HTML-тег («<a href=\"shopitem/\") в содержимом ответа, чтобы определить, имеет ли товар связанную с ним информацию о магазине.\r\n\r\nЕсли с товаром связана информация о магазине, код выполняет еще один HTTP-запрос для получения подробной информации о магазине.\r\n\r\nКод ищет определенный HTML-тег («<h3>Описание</h3><p>») в информации о магазине, чтобы извлечь описание магазина. Описание подвергается манипуляциям с целью удаления ненужных частей и его форматирования.\r\n\r\nНаконец, описание товара или магазина отображается в соответствующем текстовом поле.\r\n\r\nЕсли во время всего этого процесса возникнет какая-либо ошибка, появится окно с сообщением об ошибке «Ошибка подключения!». отображается.\r\n\r\nПомните, что это фрагмент кода из приложения Windows Forms, который взаимодействует с информацией из Интернета и обновляет графический интерфейс полученной информацией.\r\n---------------------------------------------------------------------------------------------------------------------------------------\r\nОПИСАНИЕ\r\n---------------------------\r\nСначала код проверяет, меньше ли 1 выбранный параметр в comboBox_dbSource, что говорит о том, что элемент взят из локального источника (предварительно загруженные элементы), а не из онлайн-источника базы данных.\r\n\r\nЕсли выбранный параметр меньше 1, код ищет описание, связанное с элементом, используя значение numericUpDown_itemID в качестве ключа в словаре itemDescriptions. Если найдено допустимое описание, оно обрабатывается для замены специальных символов, а затем текстовое поле textBox_description заполняется обработанным описанием.\r\n\r\nЕсли выбранный параметр больше или равен 1, код пытается получить информацию об элементе с веб-сайта в Интернете. Он отправляет HTTP-запрос на определенный URL-адрес на основе выбранного источника и идентификатора элемента.\r\n\r\nКод анализирует содержимое HTML-ответа для извлечения такой информации, как название и описание элемента. Это делается путем поиска определенных HTML-элементов на веб-страницах.\r\n\r\nОписание извлекается из HTML-ответа, а затем выполняется обработка, аналогичная первой, для удаления HTML-элементов, замены специальных символов, таких как цвета, представленные в шестнадцатеричных кодах, и замены переносов строк на специальные символы (\\\\r).\r\n\r\nОбработанное описание затем устанавливается как текст текстового поля textBox_description.\r\n\r\nЕсли во время процесса произошла ошибка, в диалоговом окне отображается сообщение об ошибке.\r\n\r\nКороче говоря, этот фрагмент кода заполняет текстовое поле textBox_description описанием элемента, которое можно получить из локального источника или с веб-сайта в зависимости от выбранных параметров. Он также выполняет некоторую обработку, чтобы гарантировать правильность форматирования отображаемого текста.";
                    break;

                case "Traditional Chinese":
                    richTextBox1.Text = "程式碼的第一部分包括一系列「使用」指令，用於匯入程式運行所需的命名空間。這使得程式碼可以利用來自不同庫的類別和功能。\r\n\r\n程式碼包含在「更新」命名空間中。它定義了一個名為「Form1」的類，該類別繼承自「Form」類別。這表示該類別代表Windows Forms圖形介面窗體。\r\n\r\n在「Form1」類別中，有一個名為「itemDescriptions」的私人變量，其類型為「SortedList」（有序集合），還有一個名為「directoryPath」的私人變量，它將目錄路徑儲存到名為「item_ext_desc.txt」的檔案中。\r\n\r\n建構子“Form1()”已定義。這是表單的建構函數，在建立該表單的實例時呼叫。它呼叫“InitializeComponent()”方法並設定表單的圖形介面。\r\n\r\n程式碼的下一個重要部分是名為「button_autoDetect_Click」的方法，它是與點擊名為「button_autoDetect」的按鈕相關的事件處理程序。這表示當按鈕被點擊時該方法將被執行。\r\n\r\n在此方法中，滑鼠遊標變成「AppStarting」指示器，表示應用程式正在執行需要一些時間才能完成的任務。\r\n\r\nif (comboBox_dbSource.SelectedIndex < 1) 條件檢查是否在名為「comboBox_dbSource」的 ComboBox 中選擇了某個項目。如果選定的索引小於 1，則程式碼將進入此區塊。這部分程式碼似乎處理與本地資料庫相關的選項。\r\n\r\n在此區塊中，程式碼嘗試根據「numericUpDown_itemID」的值從「itemDescriptions」集合中取得項目描述。如果描述非空，則會進行操作以將換行符（“\\r”）替換為“ \\r”（顯然是為了格式化）。\r\n\r\n如果ComboBox中選取的索引大於或等於1，則表示選擇了外部資料庫選項。在這種情況下，程式碼會嘗試從網路取得資訊。\r\n\r\n根據來自 ComboBox 和「numericUpDown_itemID」的資訊為 URL 建立 HTTP 請求。這表示程式碼正在嘗試存取線上專案的資訊。\r\n\r\n程式碼向 URL 發出請求並獲取 HTTP 回應。然後閱讀回覆的內容。\r\n\r\n程式碼在回應內容中尋找特定的 HTML 標籤（「<th class=\"itemHeader\"」）來擷取項目名稱。它操作字串來提取項目名稱，刪除不必要的部分。\r\n\r\n程式碼還會在回應內容中尋找另一個 HTML 標籤（「<a href=\"shopitem/」），以確定該項目是否具有相關的商店資訊。\r\n\r\n如果商店資訊與該項目相關，代碼將發出另一個 HTTP 請求以獲取詳細的商店資訊。\r\n\r\n程式碼在商店資訊中尋找特定的 HTML 標籤（“<h3>Description</h3><p>”）以提取商店描述。對描述進行處理以刪除不必要的部分並進行格式化。\r\n\r\n最後，商品或商店的描述顯示在相應的文字方塊中。\r\n\r\n如果整個過程中出現任何錯誤，就會出現「連線失敗！」錯誤訊息框。將顯示。\r\n\r\n請記住，這是來自 Windows 窗體應用程式的程式碼片段，它與來自 Web 的資訊進行互動並使用獲得的資訊更新圖形介面。\r\n---------------------------------------------------------------------------------------------------------------------------------------------------\r\n描述\r\n---------------------------\r\n首先，程式碼檢查 comboBox_dbSource 中選擇的選項是否小於 1，這表示該項目來自本地來源（預先載入的項目）而不是線上資料庫來源。\r\n\r\n如果選定的選項小於 1，則程式碼將使用 numericUpDown_itemID 的值作為 itemDescriptions 字典中的鍵來尋找與該項目相關的描述。如果找到有效的描述，則對其進行處理以替換特殊字符，然後使用處理後的描述填充 textBox_description 文字方塊。\r\n\r\n如果選定的選項大於或等於 1，則程式碼將嘗試從線上網站取得有關該項目的資訊。它會根據所選的來源和項目 ID 向特定的 URL 發送 HTTP 請求。\r\n\r\n程式碼解析 HTML 回應的內容以提取項目名稱和描述等資訊。它透過尋找網頁上的特定 HTML 元素來實現這一點。\r\n\r\n從 HTML 回應中提取描述，然後進行與第一種場景類似的處理，刪除 HTML 元素，替換十六進位代碼表示的顏色等特殊字符，並用特殊字符 (\\\\r) 替換換行符。\r\n\r\n然後將處理後的描述設定為 textBox_description 文字方塊的文字。\r\n\r\n如果在此過程中出現錯誤，對話方塊中將顯示一條錯誤訊息。\r\n\r\n簡而言之，此程式碼片段似乎用專案的描述填充了 textBox_description 文字框，該描述可以從本地來源或線上網站獲取，具體取決於所選的選項。它還執行一些處理以確保顯示的文字格式正確。";
                    break;

                default:
                    richTextBox1.Text = string.Empty;
                    break;
            }
        }
    }
}