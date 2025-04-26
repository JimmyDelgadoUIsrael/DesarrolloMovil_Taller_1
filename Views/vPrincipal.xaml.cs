namespace jdelgadoT1.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Validaciones
            if (!int.TryParse(txtIdentidicacion.Text, out int identificacion))
            {
                lblInfo.Text = "La identificaci�n debe contener solo n�meros.";
                return;
            }

            if (!int.TryParse(txtTelefono.Text, out int telefono))
            {
                lblInfo.Text = "El tel�fono debe contener solo n�meros.";
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtaApellidos.Text;
            string correo = txtCorreo.Text;
            string conCorreo = txtConCorreo.Text;

            if (correo != conCorreo)
            {
                lblInfo.Text = "Verificar que los correos coincidan.";
                return;
            }

            if (!IsValidEmail(correo))
            {
                lblInfo.Text = "Formato de correo inv�lido.";
                return;
            }

            // Guardar en archivo de texto
            string rutaDestino = @"C:\Users\Master\Downloads";
            string contenido = $"Identificaci�n: {identificacion}\nNombre: {nombre}\nApellido: {apellido}\nTel�fono: {telefono}\nCorreo: {correo}\n---\n";

            string fileName = "datos_guardados.txt";
            string filePath = Path.Combine(rutaDestino, fileName);

            //C:\Users\Master\AppData\Local\User Name\com.companyname.jdelgadot1\Data

            // A�adir al archivo (crear si no existe)
            File.AppendAllText(filePath, contenido);

            lblInfo.Text = $"Gracias {nombre} {apellido}, tus datos fueron guardados con �xito.";
        }
        catch (Exception ex)
        {
            lblInfo.Text = "ERROR al guardar: " + ex.Message;
        }
    }

    // Validar correo
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

}