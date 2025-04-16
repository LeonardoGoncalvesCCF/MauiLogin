namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Enviando o usuário para pagina de login por padrão
            MainPage = new Login();


            string? usuario_logado = null;
            
            // checando se o usuário ja fez login, se tiver feito permanecer conectado
            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (usuario_logado != null) 
                {
                    MainPage = new Protegida();
                }

            });
        }

        protected override Window CreateWindow(IActivationState? activationState) 
        { 
        
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;

        }
    }
}