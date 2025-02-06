# ComboBox Language Selector

## 📋 Sobre o Projeto

O **ComboBox Language Selector** é uma aplicação desenvolvida em C# com Windows Forms, que tem como objetivo permitir que os usuários selecionem um idioma a partir de uma lista pré-definida. O projeto foi recentemente atualizado para incluir uma funcionalidade que define uma opção padrão no `ComboBox` com o texto **"Escolha o idioma aqui"**, garantindo uma experiência mais intuitiva para os usuários.

## 🚀 Funcionalidades

- Exibe uma lista de idiomas disponíveis no `ComboBox`.
- Inclui uma opção padrão intitulada **"Escolha o idioma aqui"**.
- Garante que o idioma padrão seja exibido ao abrir o aplicativo.
- Detecta mudanças no idioma selecionado com o evento `SelectedIndexChanged`.

## 🛠️ Tecnologias Utilizadas

- **C#**: Linguagem de programação principal.
- **Windows Forms**: Framework para criação de interfaces gráficas.

## 📂 Estrutura do Projeto

```
ComboBoxLanguageSelector/
├── Properties/        # Configurações do projeto
├── bin/               # Arquivos binários gerados
├── obj/               # Arquivos temporários de compilação
├── Form1.cs           # Código principal da interface
├── Form1.Designer.cs  # Designer gerado automaticamente
├── Program.cs         # Ponto de entrada da aplicação
└── README.md          # Documentação do projeto
```

## 🔧 Como Executar o Projeto

1. Clone este repositório para sua máquina local:

   ```bash
   git clone https://github.com/seu-usuario/Pw-Teste-Eventos.git
   ```

2. Abra o projeto no Visual Studio.

3. Compile o projeto pressionando `Ctrl + Shift + B` ou clique em **Build Solution** no menu **Build**.

4. Execute o projeto pressionando `F5` ou clicando em **Start**.

5. A interface será exibida com o `ComboBox` configurado para exibir a mensagem padrão **"Escolha o idioma aqui"**.

## ✨ Demonstração

**Tela inicial do projeto:**

- O `ComboBox` mostra por padrão:

  ```
  Escolha o idioma aqui
  ```

- Opções disponíveis no `ComboBox`:

  - English
  - Russian
  - Traditional Chinese

## 📌 Exemplo de Código

Aqui está um trecho do código que adiciona a funcionalidade de seleção padrão:

```csharp
public Form1()
{
    InitializeComponent();

    // Adiciona as linguagens no comboBox_Language
    comboBox_Language.Items.Add("Escolha o idioma aqui"); // Opção padrão
    comboBox_Language.Items.Add("English");
    comboBox_Language.Items.Add("Russian");
    comboBox_Language.Items.Add("Traditional Chinese");

    // Define o item padrão selecionado
    comboBox_Language.SelectedIndex = 0;

    // Define o evento de alteração de seleção
    comboBox_Language.SelectedIndexChanged += ComboBox_Language_SelectedIndexChanged;
}
```

## 📚 Próximos Passos

-

## 🤝 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request no repositório.

## 📝 Licença

Este projeto está sob a licença MIT. Para mais detalhes, leia o arquivo `LICENSE`.

---

\*\*Desenvolvido por: Giovani Chaves\
 Data: 06/02/2025

