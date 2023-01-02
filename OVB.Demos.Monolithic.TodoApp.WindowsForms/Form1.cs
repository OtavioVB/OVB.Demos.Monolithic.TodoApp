using System.Data.SQLite;

namespace OVB.Demos.Monolithic.TodoApp.WindowsForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void CriarTarefaButtonClick(object sender, EventArgs e)
    {
        var sqliteConnection = new SQLiteConnection("Data source=Todoapp.db");
        sqliteConnection.Open();
        var command = sqliteConnection.CreateCommand();
        command.CommandText = "INSERT INTO Assignments (Identifier, Title) VALUES (@Identifier, @Title);";
        command.Parameters.AddWithValue("@Identifier", Guid.NewGuid().ToString());
        command.Parameters.AddWithValue("@Title", textBoxTarefa.Text);
        command.ExecuteNonQuery();
        sqliteConnection.Close();
    }
}