namespace Aranda.Productos.Infrastructure.Migrations
{
    using Aranda.Productos.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aranda.Productos.Infrastructure.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aranda.Productos.Infrastructure.Persistence.ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(
                c => c.Nombre,
                new Category { Nombre = "Periféricos"},
                new Category { Nombre = "Electronica" },
                new Category { Nombre = "Software" }
                );
            context.Products.AddOrUpdate(
              p => p.Nombre,
              new Product
              {
                  Nombre = "Laptop Dell XPS 15",
                  Descripcion = "Potente laptop para profesionales con pantalla 4K.",
                  CategoriaId = 2,
                  BlobImagen = "images/xps15.jpg"
              },
              new Product
              {
                  Nombre = "Mouse Logitech MX Master 3S",
                  Descripcion = "Mouse ergonómico inalámbrico con scroll electromagnético.",
                  CategoriaId = 1,
                  BlobImagen = "images/mxmaster3s.jpg"
              },
              new Product
              {
                  Nombre = "Mouse Logitech MX Master 3",
                  Descripcion = "Mouse ergonómico inalámbrico con scroll electromagnético.",
                  CategoriaId = 1,
                  BlobImagen = "images/mxmaster3.jpg"
              },
              new Product
              {
                  Nombre = "Teclado Mecánico Keychron K2",
                  Descripcion = "Teclado compacto 75% con switches Gateron Brown.",
                  CategoriaId = 1,
                  BlobImagen = "images/keychronk2.jpg"
              },
              new Product
              {
                  Nombre = "Monitor LG UltraWide 34",
                  Descripcion = "Monitor curvo de 34 pulgadas para mayor productividad.",
                  CategoriaId = 2,
                  BlobImagen = "images/lgultrawide.jpg"
              },
              new Product
              {
                  Nombre = "Portatil Lenovo ThinkPad X1 Carbon",
                  Descripcion = "Portatil Lenovo ThinkPad X1 Carbon",
                  CategoriaId = 2,
                  BlobImagen = "images/lenovox1carbon.jpg"
              },
              new Product
              {
                  Nombre = "Celular Samsung Galaxy S23",
                  Descripcion = "Celular Samsung Galaxy S23",
                  CategoriaId = 2,
                  BlobImagen = "images/samsunggalaxyS23.jpg"
              },
              new Product
              {
                  Nombre = "Xiaomi Redmi Note 12",
                  Descripcion = "Celular Xiaomi Redmi Note 12",
                  CategoriaId = 2,
                  BlobImagen = "images/xiaomiredminote12.jpg"
              },
              new Product
              {
                  Nombre = "Xbox Series X",
                  Descripcion = "Xbox Series X",
                  CategoriaId = 2,
                  BlobImagen = "images/xboxseriesx.jpg"
              },
              new Product
              {
                  Nombre = "Playstation 5",
                  Descripcion = "Playstation 5",
                  CategoriaId = 2,
                  BlobImagen = "images/playstation5.jpg"
              },
              new Product
              {
                  Nombre = "Router TP-Link Archer C7",
                  Descripcion = "Router TP-Link Archer C7",
                  CategoriaId = 2,
                  BlobImagen = "images/tp-linkarcherc7.jpg"
              },
              new Product
              {
                  Nombre = "GTA V",
                  Descripcion = "GTA V",
                  CategoriaId = 3,
                  BlobImagen = "images/gtav.jpg"
              },
              new Product
              {
                  Nombre = "Nevera Samsung RB30K5110SG",
                  Descripcion = "Nevera Samsung RB30K5110SG",
                  CategoriaId = 1,
                  BlobImagen = "images/neverasamsungrb30k5110sg.jpg"
              },
              new Product
              {
                  Nombre = "Windows 11 Pro",
                  Descripcion = "Sistema operativo Windows 11 Pro.",
                  CategoriaId = 3,
                  BlobImagen = "images/windows11.jpg"
              },
              new Product
              {
                  Nombre = "Office 365",
                  Descripcion = "Office 365 para mayor productividad.",
                  CategoriaId = 3,
                  BlobImagen = "images/office365.jpg"
              },
              new Product
              {
                  Nombre = "Adobe Photoshop",
                  Descripcion = "Adobe Photoshop para edición de imágenes.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobephotoshop.jpg"
              },
              new Product
              {
                  Nombre = "Adobe Illustrator",
                  Descripcion = "Adobe Illustrator para creación de gráficos vectoriales.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobeillustrator.jpg"
              },
              new Product
              {
                  Nombre = "Adobe InDesign",
                  Descripcion = "Adobe InDesign para creación de documentos.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobeindesign.jpg"
              },
              new Product
              {
                  Nombre = "Adobe Acrobat Pro",
                  Descripcion = "Adobe Acrobat Pro para creación de documentos.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobeacrobatpro.jpg"
              },
              new Product
              {
                  Nombre = "Adobe Premiere Pro",
                  Descripcion = "Adobe Premiere Pro para edición de videos.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobepremierepro.jpg"
              },
              new Product
              {
                  Nombre = "Auriculares Sony WH-1000XM5",
                  Descripcion = "Auriculares Sony WH-1000XM5",
                  CategoriaId = 2,
                  BlobImagen = "images/auricularssonywh1000xm5.jpg"
              }
            , new Product
              {
                  Nombre = "Microondas LG MS2075",
                  Descripcion = "Microondas LG MS2075",
                  CategoriaId = 1,
                  BlobImagen = "images/microondaslgms2075.jpg"
              }, 
              new Product
              {
                  Nombre = "Aspiradora Dyson V15 Detect Slim",
                  Descripcion = "Aspiradora Dyson V15 Detect Slim",
                  CategoriaId = 1,
                  BlobImagen = "images/dysonv15detectslim.jpg"
              },
              new Product
              {
                  Nombre = "Cafetera Philips HD7443 1000W",
                  Descripcion = "Cafetera Philips HD7443",
                  CategoriaId = 1,
                  BlobImagen = "images/cafeterahd7443.jpg"
              },
              new Product
              {
                  Nombre = "Maquina de coser Singer 14T524",
                  Descripcion = "Maquina de coser Singer 14T524",
                  CategoriaId = 1,
                  BlobImagen = "images/maquinacosersinger14t524.jpg"
              },
              new Product
              {
                  Nombre = "Licuadora Oster BLSTPYG1210RBG",
                  Descripcion = "Licuadora Oster con motor de 1100W.",
                  CategoriaId = 1,
                  BlobImagen = "images/licuadoraoster.jpg"
              },
              new Product
              {
                  Nombre = "Tostadora Black+Decker TR1278B",
                  Descripcion = "Tostadora de 2 rebanadas con ranuras anchas.",
                  CategoriaId = 1,
                  BlobImagen = "images/tostadora.jpg"
              },
              new Product
              {
                  Nombre = "Plancha de Ropa Philips GC1028/20",
                  Descripcion = "Plancha de ropa con suela antiadherente.",
                  CategoriaId = 1,
                  BlobImagen = "images/plancha.jpg"
              },
              new Product
              {
                  Nombre = "Secador de Pelo Remington D3190",
                  Descripcion = "Secador de pelo con tecnología iónica.",
                  CategoriaId = 1,
                  BlobImagen = "images/secadorpelo.jpg"
              },
              new Product
              {
                  Nombre = "Smart TV Samsung Crystal UHD 55",
                  Descripcion = "Televisor inteligente 4K de 55 pulgadas.",
                  CategoriaId = 2,
                  BlobImagen = "images/smarttvsamsung.jpg"
              },
              new Product
              {
                  Nombre = "Barra de Sonido LG SN5Y",
                  Descripcion = "Barra de sonido 2.1 canales con subwoofer inalámbrico.",
                  CategoriaId = 2,
                  BlobImagen = "images/barrasonido.jpg"
              },
              new Product
              {
                  Nombre = "Impresora Multifuncional Epson EcoTank L3150",
                  Descripcion = "Impresora con sistema de tanques de tinta rellenables.",
                  CategoriaId = 1,
                  BlobImagen = "images/impresoraepson.jpg"
              },
              new Product
              {
                  Nombre = "Cámara de Seguridad TP-Link Tapo C200",
                  Descripcion = "Cámara IP Wi-Fi con visión nocturna.",
                  CategoriaId = 2,
                  BlobImagen = "images/camaraseguridad.jpg"
              },
              new Product
              {
                  Nombre = "Tablet Samsung Galaxy Tab S8",
                  Descripcion = "Tablet de alta gama con S Pen incluido.",
                  CategoriaId = 2,
                  BlobImagen = "images/tabletsamsung.jpg"
              },
              new Product
              {
                  Nombre = "Apple Watch Series 8",
                  Descripcion = "Smartwatch con seguimiento de salud avanzado.",
                  CategoriaId = 2,
                  BlobImagen = "images/applewatch.jpg"
              },
              new Product
              {
                  Nombre = "Freidora de Aire Philips HD9270/90",
                  Descripcion = "Freidora de aire de 6.2 litros de capacidad.",
                  CategoriaId = 1,
                  BlobImagen = "images/freidoraaire.jpg"
              },
              new Product
              {
                  Nombre = "Ventilador de Torre Honeywell HYF290B",
                  Descripcion = "Ventilador oscilante con control remoto.",
                  CategoriaId = 1,
                  BlobImagen = "images/ventilador.jpg"
              },
              new Product
              {
                  Nombre = "Google Chromecast con Google TV",
                  Descripcion = "Dispositivo de streaming con control por voz.",
                  CategoriaId = 2,
                  BlobImagen = "images/chromecast.jpg"
              },
              new Product
              {
                  Nombre = "Amazon Echo Dot (4th Gen)",
                  Descripcion = "Altavoz inteligente con Alexa.",
                  CategoriaId = 2,
                  BlobImagen = "images/echodot.jpg"
              },
              new Product
              {
                  Nombre = "Robot Aspirador Roomba i3+",
                  Descripcion = "Robot aspirador con vaciado automático de depósito.",
                  CategoriaId = 1,
                  BlobImagen = "images/roomba.jpg"
              },
              new Product
              {
                  Nombre = "Sistema de Malla Wi-Fi TP-Link Deco M4",
                  Descripcion = "Sistema Wi-Fi de malla para cobertura en todo el hogar.",
                  CategoriaId = 2,
                  BlobImagen = "images/tp-linkdecom4.jpg"
              },
              new Product
              {
                  Nombre = "Cargador Portátil Anker PowerCore Essential 20000",
                  Descripcion = "Power bank de alta capacidad.",
                  CategoriaId = 2,
                  BlobImagen = "images/ankerpowercore.jpg"
              },
              new Product
              {
                  Nombre = "Proyector Portátil Anker Nebula Capsule II",
                  Descripcion = "Mini proyector con Android TV.",
                  CategoriaId = 2,
                  BlobImagen = "images/nebula_capsule.jpg"
              },
              new Product
              {
                  Nombre = "Nintendo Switch",
                  Descripcion = "Consola de videojuegos híbrida.",
                  CategoriaId = 2,
                  BlobImagen = "images/nintendoswitch.jpg"
              },
              new Product
              {
                  Nombre = "Kindle Paperwhite",
                  Descripcion = "Lector de libros electrónicos con luz frontal.",
                  CategoriaId = 2,
                  BlobImagen = "images/kindlepaperwhite.jpg"
              },
              new Product
              {
                  Nombre = "Altavoz Bluetooth JBL Flip 5",
                  Descripcion = "Altavoz portátil resistente al agua.",
                  CategoriaId = 2,
                  BlobImagen = "images/jblflip5.jpg"
              },
              new Product
              {
                  Nombre = "Auriculares Inalámbricos Apple AirPods Pro (2nd Gen)",
                  Descripcion = "Auriculares con cancelación activa de ruido.",
                  CategoriaId = 2,
                  BlobImagen = "images/airpodspro.jpg"
              },
              new Product
              {
                  Nombre = "Teclado Inalámbrico Logitech K380",
                  Descripcion = "Teclado multidispositivo compacto.",
                  CategoriaId = 1,
                  BlobImagen = "images/logitechk380.jpg"
              },
              new Product
              {
                  Nombre = "Ratón Inalámbrico Microsoft Arc Mouse",
                  Descripcion = "Ratón ultraplano y plegable.",
                  CategoriaId = 1,
                  BlobImagen = "images/microsoftarcmouse.jpg"
              }
            , new Product
              {
                  Nombre = "Monitor Dell UltraSharp U2721DE",
                  Descripcion = "Monitor de 27 pulgadas con conectividad USB-C.",
                  CategoriaId = 1,
                  BlobImagen = "images/dell_u2721de.jpg"
              },
              new Product
              {
                  Nombre = "Webcam Logitech C920S",
                  Descripcion = "Webcam Full HD 1080p con tapa de privacidad.",
                  CategoriaId = 1,
                  BlobImagen = "images/logitech_c920s.jpg"
              },
              new Product
              {
                  Nombre = "Router Gaming ASUS RT-AX88U",
                  Descripcion = "Router Wi-Fi 6 de alto rendimiento para gaming.",
                  CategoriaId = 2,
                  BlobImagen = "images/asus_rtax88u.jpg"
              },
              new Product
              {
                  Nombre = "Disco Duro Externo Seagate Portable 2TB",
                  Descripcion = "Disco duro portátil de 2TB USB 3.0.",
                  CategoriaId = 1,
                  BlobImagen = "images/seagate_2tb.jpg"
              },
              new Product
              {
                  Nombre = "Memoria USB SanDisk Ultra Flair 128GB",
                  Descripcion = "Memoria USB 3.0 de alta velocidad.",
                  CategoriaId = 1,
                  BlobImagen = "images/sandisk_128gb.jpg"
              },
              new Product
              {
                  Nombre = "Tarjeta Gráfica NVIDIA GeForce RTX 3080",
                  Descripcion = "Tarjeta gráfica de alto rendimiento para juegos y diseño.",
                  CategoriaId = 1,
                  BlobImagen = "images/rtx3080.jpg"
              },
              new Product
              {
                  Nombre = "Procesador Intel Core i9-12900K",
                  Descripcion = "Procesador de última generación para computadoras de alto rendimiento.",
                  CategoriaId = 1,
                  BlobImagen = "images/i9_12900k.jpg"
              },
              new Product
              {
                  Nombre = "Placa Base ASUS ROG Strix Z690-E Gaming WiFi",
                  Descripcion = "Placa base compatible con procesadores Intel de 12ª generación.",
                  CategoriaId = 1,
                  BlobImagen = "images/asus_z690e.jpg"
              },
              new Product
              {
                  Nombre = "Memoria RAM Corsair Vengeance RGB Pro 32GB (2x16GB) DDR4 3200MHz",
                  Descripcion = "Kit de memoria RAM de alta velocidad con iluminación RGB.",
                  CategoriaId = 1,
                  BlobImagen = "images/corsair_32gb.jpg"
              },
              new Product
              {
                  Nombre = "Fuente de Poder Seasonic Focus GX-850, 850W 80+ Gold",
                  Descripcion = "Fuente de poder modular de 850W con certificación 80+ Gold.",
                  CategoriaId = 1,
                  BlobImagen = "images/seasonic_850w.jpg"
              },
              new Product
              {
                  Nombre = "Gabinete NZXT H510 Elite",
                  Descripcion = "Gabinete ATX compacto con panel frontal de vidrio templado.",
                  CategoriaId = 1,
                  BlobImagen = "images/nzxt_h510elite.jpg"
              },
              new Product
              {
                  Nombre = "Sistema de Enfriamiento Líquido Corsair iCUE H150i ELITE CAPELLIX",
                  Descripcion = "Enfriamiento líquido AIO de 360mm con iluminación RGB.",
                  CategoriaId = 1,
                  BlobImagen = "images/corsair_h150i.jpg"
              },
              new Product
              {
                  Nombre = "SSD Samsung 970 EVO Plus 1TB NVMe M.2",
                  Descripcion = "Unidad de estado sólido NVMe M.2 de alta velocidad.",
                  CategoriaId = 1,
                  BlobImagen = "images/samsung_970evo.jpg"
              },
              new Product
              {
                  Nombre = "Sistema Operativo Ubuntu 22.04 LTS",
                  Descripcion = "Sistema operativo de código abierto basado en Linux.",
                  CategoriaId = 3,
                  BlobImagen = "images/ubuntu.jpg"
              },
              new Product
              {
                  Nombre = "Microsoft Visual Studio 2022",
                  Descripcion = "Entorno de desarrollo integrado para .NET y C++.",
                  CategoriaId = 3,
                  BlobImagen = "images/visualstudio.jpg"
              },
              new Product
              {
                  Nombre = "JetBrains Rider",
                  Descripcion = "IDE multiplataforma para desarrollo .NET.",
                  CategoriaId = 3,
                  BlobImagen = "images/jetbrains_rider.jpg"
              },
              new Product
              {
                  Nombre = "Docker Desktop",
                  Descripcion = "Plataforma para desarrollar, enviar y ejecutar aplicaciones en contenedores.",
                  CategoriaId = 3,
                  BlobImagen = "images/docker_desktop.jpg"
              },
              new Product
              {
                  Nombre = "Git Bash",
                  Descripcion = "Emulador de terminal para usar Git en Windows.",
                  CategoriaId = 3,
                  BlobImagen = "images/git_bash.jpg"
              },
              new Product
              {
                  Nombre = "Postman",
                  Descripcion = "Herramienta de colaboración para desarrollo de API.",
                  CategoriaId = 3,
                  BlobImagen = "images/postman.jpg"
              },
              new Product
              {
                  Nombre = "SQL Server Management Studio (SSMS)",
                  Descripcion = "Entorno integrado para administrar cualquier infraestructura SQL.",
                  CategoriaId = 3,
                  BlobImagen = "images/ssms.jpg"
              },
              new Product
              {
                  Nombre = "DBeaver Community",
                  Descripcion = "Cliente SQL universal y herramienta de base de datos.",
                  CategoriaId = 3,
                  BlobImagen = "images/dbeaver.jpg"
              },
              new Product
              {
                  Nombre = "Notepad++",
                  Descripcion = "Editor de texto y editor de código fuente.",
                  CategoriaId = 3,
                  BlobImagen = "images/notepad++.jpg"
              },
              new Product
              {
                  Nombre = "Slack",
                  Descripcion = "Herramienta de comunicación para equipos de trabajo.",
                  CategoriaId = 3,
                  BlobImagen = "images/slack.jpg"
              },
              new Product
              {
                  Nombre = "Microsoft Teams",
                  Descripcion = "Plataforma unificada de comunicación y colaboración.",
                  CategoriaId = 3,
                  BlobImagen = "images/microsoft_teams.jpg"
              },
              new Product
              {
                  Nombre = "Zoom",
                  Descripcion = "Plataforma de videoconferencias.",
                  CategoriaId = 3,
                  BlobImagen = "images/zoom.jpg"
              },
              new Product
              {
                  Nombre = "Google Chrome",
                  Descripcion = "Navegador web rápido y seguro.",
                  CategoriaId = 3,
                  BlobImagen = "images/google_chrome.jpg"
              },
              new Product
              {
                  Nombre = "Mozilla Firefox",
                  Descripcion = "Navegador web de código abierto y personalizable.",
                  CategoriaId = 3,
                  BlobImagen = "images/mozilla_firefox.jpg"
              },
              new Product
              {
                  Nombre = "Malwarebytes Premium",
                  Descripcion = "Software antimalware y antivirus.",
                  CategoriaId = 3,
                  BlobImagen = "images/malwarebytes.jpg"
              },
              new Product
              {
                  Nombre = "VPN ExpressVPN",
                  Descripcion = "Servicio VPN rápido y seguro.",
                  CategoriaId = 3,
                  BlobImagen = "images/expressvpn.jpg"
              },
              new Product
              {
                  Nombre = "LastPass Premium",
                  Descripcion = "Gestor de contraseñas con funciones premium.",
                  CategoriaId = 3,
                  BlobImagen = "images/lastpass.jpg"
              },
              new Product
              {
                  Nombre = "Spotify Premium",
                  Descripcion = "Servicio de streaming de música sin anuncios.",
                  CategoriaId = 3,
                  BlobImagen = "images/spotify_premium.jpg"
              },
              new Product
              {
                  Nombre = "Netflix Premium",
                  Descripcion = "Servicio de streaming de películas y series en 4K.",
                  CategoriaId = 3,
                  BlobImagen = "images/netflix_premium.jpg"
              },
              new Product
              {
                  Nombre = "Disney+ Premium",
                  Descripcion = "Servicio de streaming de Disney, Pixar, Marvel, Star Wars y National Geographic.",
                  CategoriaId = 3,
                  BlobImagen = "images/disney_plus_premium.jpg"
              },
              new Product
              {
                  Nombre = "Adobe Creative Cloud All Apps",
                  Descripcion = "Suscripción a todas las aplicaciones de Adobe Creative Cloud.",
                  CategoriaId = 3,
                  BlobImagen = "images/adobe_creative_cloud.jpg"
              },
              new Product
              {
                  Nombre = "Grammarly Premium",
                  Descripcion = "Asistente de escritura con funciones avanzadas.",
                  CategoriaId = 3,
                  BlobImagen = "images/grammarly_premium.jpg"
              },
              new Product
              {
                  Nombre = "Evernote Premium",
                  Descripcion = "Aplicación de toma de notas y organización personal.",
                  CategoriaId = 3,
                  BlobImagen = "images/evernote_premium.jpg"
              },
              new Product
              {
                  Nombre = "Microsoft Office Home & Business 2021",
                  Descripcion = "Licencia perpetua de Office para uso doméstico y empresarial.",
                  CategoriaId = 3,
                  BlobImagen = "images/office_home_business.jpg"
              },
              new Product
              {
                  Nombre = "Windows Server 2022 Standard",
                  Descripcion = "Sistema operativo de servidor de Microsoft.",
                  CategoriaId = 3,
                  BlobImagen = "images/windows_server_2022.jpg"
              },
              new Product
              {
                  Nombre = "SQL Server 2019 Standard",
                  Descripcion = "Sistema de gestión de bases de datos relacionales de Microsoft.",
                  CategoriaId = 3,
                  BlobImagen = "images/sql_server_2019.jpg"
              },
              new Product
              {
                  Nombre = "Visual Studio Code",
                  Descripcion = "Editor de código fuente ligero y potente.",
                  CategoriaId = 3,
                  BlobImagen = "images/vscode.jpg"
              },
              new Product
              {
                  Nombre = "Android Studio",
                  Descripcion = "Entorno de desarrollo integrado oficial para la plataforma Android.",
                  CategoriaId = 3,
                  BlobImagen = "images/android_studio.jpg"
              },
              new Product
              {
                  Nombre = "Xcode",
                  Descripcion = "Entorno de desarrollo integrado de Apple para macOS.",
                  CategoriaId = 3,
                  BlobImagen = "images/xcode.jpg"
              },
              new Product
              {
                  Nombre = "Unity 3D Pro",
                  Descripcion = "Motor de videojuegos multiplataforma.",
                  CategoriaId = 3,
                  BlobImagen = "images/unity_3d_pro.jpg"
              },
              new Product
              {
                  Nombre = "Unreal Engine 5",
                  Descripcion = "Motor de videojuegos avanzado para gráficos fotorrealistas.",
                  CategoriaId = 3,
                  BlobImagen = "images/unreal_engine_5.jpg"
              },
              new Product
              {
                  Nombre = "Blender",
                  Descripcion = "Software de modelado, renderizado y animación 3D.",
                  CategoriaId = 3,
                  BlobImagen = "images/blender.jpg"
              },
              new Product
              {
                  Nombre = "Figma",
                  Descripcion = "Herramienta de diseño de interfaz de usuario y prototipado.",
                  CategoriaId = 3,
                  BlobImagen = "images/figma.jpg"
              },
              new Product
              {
                  Nombre = "Sketch",
                  Descripcion = "Herramienta de diseño vectorial para macOS.",
                  CategoriaId = 3,
                  BlobImagen = "images/sketch.jpg"
              },
              new Product
              {
                  Nombre = "Slack Pro",
                  Descripcion = "Herramienta de comunicación para equipos de trabajo con funciones avanzadas.",
                  CategoriaId = 3,
                  BlobImagen = "images/slack_pro.jpg"
              },
              new Product
              {
                  Nombre = "Jira Software",
                  Descripcion = "Herramienta de seguimiento de proyectos y gestión de incidencias.",
                  CategoriaId = 3,
                  BlobImagen = "images/jira_software.jpg"
              },
              new Product
              {
                  Nombre = "Confluence Premium",
                  Descripcion = "Espacio de trabajo colaborativo para equipos.",
                  CategoriaId = 3,
                  BlobImagen = "images/confluence_premium.jpg"
              }
            );

            context.SaveChanges();
        }
    }
}
