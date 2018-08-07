namespace SeparadorNombres
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The separador nombres.
    /// </summary>
    public class SeparadorNombres
    {
        /// <summary>
        /// The personas.
        /// </summary>
        public readonly Dictionary<string, Persona> Personas = new Dictionary<string, Persona>();

        /// <summary>
        ///     Lista de aquellos nombre que no se pudieron definir y calcular la separacion entre
        ///     sus nombres, apellido paterno y apellido paterno.
        /// </summary>
        public readonly HashSet<string> Indefinidos = new HashSet<string>();

        /// <summary>
        ///     La lista de apellidos.
        /// </summary>
        /// <remarks>Apellidos de una sola palabra que no se confundan con algun nombre.</remarks>
        private readonly IEnumerable<string> Apellidos = new HashSet<string>
        {
            "ABUNDIS", "ABUNDIZ", "ACEVEDO", "ACEVES", "ACOSTA", "AGUALLO", "AGUAS", "AGUAYO", "AGUIAR", "AGUILA", "AGUILAR", "AGUILERA", "AGUIÑAGA", "AGUIRRE", "ALANIZ", "ALATORRE", "ALBA", "ALBAÑIL", "ALBAREZ", "ALCALA", "ALCANTAR", "ALCARAS", "ALCARAZ", "ALDANA", "ALDAPE", "ALEMAN", "ALFARO", "ALFEREZ", "ALMAGUER", "ALMARAZ", "ALMENDARIZ", "ALPIZAR", "ALVARADO", "ALVARES", "ALVAREZ", "ALVISO", "ALVIZO", "AMBRIZ", "ANAYA", "ANDRADE", "ANGULO", "ANTIMO", "ANZUA", "APARICIO", "APOLINAR", "AQUINO", "ARAIZA", "ARAMBULA", "ARANDA", "ARANGURE", "ARAUJO", "ARELLANO", "ARENAS", "ARGUELLES", "ARIAS", "ARMENDARIZ", "ARMENTA", "ARMIJO", "ARREASOLA", "ARREOLA", "ARRIAGA", "ARTEAGA", "ARTEGA", "ARTIAGA", "ARZOLA", "ATILANO", "AVALOS", "AVELAR", "AVILA", "AYON", "AZPEITIA",
            "BADILLO", "BALDERAS", "BALTAZAR", "BALTIERRA", "BANDA", "BAÑUELOS", "BARAJAS", "BARBA", "BARBOSA", "BARRAGAN", "BARRAZA", "BARRENO", "BARRERA", "BARRERAS", "BARRIENTOS", "BARRIOS", "BARRON", "BAUTISTA", "BECERRA", "BELMARES", "BELMONTES", "BELTRAN", "BERMEJO", "BERNAL", "BLANCAS", "BLANCO", "BOCANEGRA", "BOLAÑOS", "BONILLA", "BRICEÑO", "BRIONES", "BRISEÑO", "BRISUEÑO", "BRIZEÑO", "BRIZUELA", "BUENO", "BUSS", "BUSTAMANTE", "BUSTOS",
            "CABELLO", "CABRALES", "CABRALEZ", "CABRERA", "CADENA", "CADENAS", "CAJERO", "CALDERON", "CALVILLO", "CAMACHO", "CAMARILLO", "CAMPA", "CAMPOS", "CANDELAS", "CANELA", "CANELAS", "CANIZALEZ", "CANO", "CARBAJAL", "CARDENAS", "CARDONA", "CARMONA", "CARRANZA", "CARRASCO", "CARRAZCO", "CARREÑO", "CARREON", "CARRERA", "CARRERAS", "CARRERO", "CARRILLO", "CARRION", "CARRIZALES", "CARRIZALEZ", "CASAS", "CASILLAS", "CASTAÑEDA", "CASTILLO", "CASTORENA", "CASTRO", "CAZARES", "CEDILLO", "CEJA", "CENTENO", "CEPEDA", "CERDA", "CERNA", "CERVANTES", "CESAR", "CHABEZ", "CHAPA", "CHAVEZ", "CHIA", "CHICO", "CHINO", "CHUCA", "CISNEROS", "COLCHADO", "COLIMA", "COLLAZO", "COLMENERO", "COLUNGA", "CONCHAS", "CONTRERAS", "CORDOVA", "CORNEJO", "CORONA", "CORONADO", "CORPUS", "CORREA", "CORTES", "CORTEZ", "COSTILLA", "COVARRUBIAS", "CUELLAR", "CUEVA", "CUEVAS",
            "DAVALOS", "DAVILA", "DELGADILLO", "DELGADO", "DIAZ", "DIMAS", "DIOSDADO", "DOMINGUEZ", "DONOSO", "DUARTE", "DUEÑAS", "DUEÑAZ", "DUEÑES", "DUEÑEZ", "DURAN", "DURON",
            "ELIZONDO", "ENCINO", "ENRIQUES", "ENRIQUEZ", "ESCALANTE", "ESCALERA", "ESCALONA", "ESCAMILLA", "ESCANAME", "ESCAREÑO", "ESCOBAR", "ESCOBEDO", "ESCOTO", "ESPARZA", "ESPINO", "ESPINOSA", "ESPINOZA", "ESPITIA", "ESQUEDA", "ESQUIVEL", "ESTANISLAO", "ESTRADA", "EZQUIVEL",
            "FABELA", "FACIO", "FAVELA", "FAZ", "FERNANDEZ", "FIGUEROA", "FLORES", "FONSECA", "FRANCO", "FRESNILLO", "FRIAS", "FRUTOS",
            "GAITAN", "GALARZA", "GALAVIZ", "GALBAN", "GALINDO", "GALLARDO", "GALLEGOS", "GALLO", "GALVAN", "GAMBOA", "GAMES", "GAMEZ", "GANDARA", "GARCIA", "GARDEA", "GARIBAY", "GARNICA", "GARROSO", "GASCON", "GATICA", "GAYTAN", "GAZCON", "GIL", "GODINEZ", "GOMEZ", "GONSALEZ", "GONZALES", "GONZALEZ", "GRAGEDA", "GRAJEDA", "GRANADOS", "GRIMALDO", "GUADIAN", "GUAJARDO", "GUARDADO", "GUEL", "GUERRA", "GUERRERO", "GUEVARA", "GUILLEN", "GUIZADO", "GUIZAR", "GUTIERREZ", "GUZMAN",
            "HELGUERA", "HEREDIA", "HERMOSILLO", "HERNANDEZ", "HERRERA", "HIDALGO", "HIROSAWA", "HOLGUIN", "HORTA", "HUERTA", "HUIZAR", "HURTADO",
            "IBARRA", "IÑIGUEZ", "ISORDIA",
            "JAIMEZ", "JARA", "JASSO", "JAUREGUI", "JIMENEZ", "JMENEZ", "JUAREZ",
            "KOSONOY",
            "LADRONDEGUEVARA", "LANDAVERDE", "LANDEROS", "LARA", "LARES", "LAZARIN", "LEAL", "LECHUGA", "LEDESMA", "LEDEZMA", "LEMUS", "LEOS", "LIBRADO", "LICON", "LIMON", "LIRA", "LIZCANO", "LLANOS", "LOERA", "LOMAS", "LOMELI", "LOPEZ", "LORENZANA", "LOZA", "LOZANO", "LUEVANO", "LUEVANOS", "LUGO", "LUJAN", "LUPERCIO",
            "MACIAS", "MAGAÑA", "MALDONADO", "MALTOS", "MANCHA", "MANCILLAS", "MANRIQUEZ", "MARAVILLAS", "MARAVILLAZ", "MARCELIANO", "MARENTES", "MARES", "MARIN", "MARISCAL", "MARQUEZ", "MARRUFO", "MARTINEZ", "MATA", "MAYA", "MAYORGA", "MEDEL", "MEDELLIN", "MEDINA", "MEDRANO", "MEJIA", "MELANO", "MELENDREZ", "MENA", "MENDEZ", "MENDOZA", "MERCADO", "MEZA", "MILANO", "MILLAN", "MIRANDA", "MIRELES", "MIXTEGA", "MOCTEZUMA", "MOJICA", "MOLINA", "MONCADA", "MONJARAS", "MONSIVAIS", "MONTALBO", "MONTAN", "MONTALGO", "MONTALVO", "MONTANTE", "MONTAÑEZ", "MONTELONGO", "MONTES", "MONTIEL", "MONTOYA", "MORA", "MORALES", "MORAN", "MORENO", "MORONES", "MOSQUEDA", "MOTA", "MUÑOZ", "MURGUIA", "MURILLO", "MURO",
            "NAJAR", "NAJERA", "NARVAEZ", "NAVA", "NAVARRO", "NIEVES", "NIÑO", "NOGALES", "NOGUEZ", "NOLAZCO", "NORIEGA", "NUÑEZ",
            "OBREGON", "OCEGUEDA", "OCEGUERA", "OCHOA", "OJEDA", "OLBERA", "OLIVARES", "OLIVAREZ", "OLMEDA", "OLMOS", "OLVERA", "ORDOÑEZ", "ORNELAS", "OROPEZA", "OROZCO", "ORTA", "ORTEGA", "ORTIZ", "OSORIO", "OVALLE",
            "PACHECO", "PACHUCA", "PADILLA", "PAEZ", "PAIZ", "PALACIOS", "PALMA", "PALOMAR", "PALOMARES", "PALOS", "PAREDES", "PAREDEZ", "PARTIDA", "PASCUAL", "PATIÑO", "PEDROZA", "PELAYO", "PEÑA", "PEREZ", "PERUSQUIA", "PICASO", "PICAZO", "PICON", "PINEDA", "PIÑA", "PLACENCIA", "PLASCENCIA", "PLASENCIA", "PLAZOLA", "POLINA", "PONCE", "PORTILLO", "PRADO", "PRECIADO", "PRIETO", "PUENTE", "PUENTES", "PUGA", "PURECO",
            "QUEZADA", "QUIJAS", "QUINTANA", "QUINTERO", "QUINTANILLA", "QUIROZ",
            "RALLAS", "RAMIREZ", "RAMOS", "RANGEL", "RAUIZ", "RAYAS", "RAZO", "RAZON", "RECENDEZ", "REGINO", "RENTERIA", "REVILLA", "REYES", "REYNOSO", "RICO", "RINCON", "RIOS", "RIVAS", "RIVERA", "RIVERO", "ROBELO", "ROBLES", "ROCHA", "RODRIGUEZ", "ROJAS", "ROMERO", "ROMO", "ROQUE", "ROSALES", "ROSARIO", "ROSAS", "ROUGON", "RUBALCABA", "RUBIO", "RUEDA", "RUELAS", "RUIZ", "RUVALCABA",
            "SAINES", "SAINEZ", "SAINS", "SAINZ", "SALAS", "SALAZAR", "SALCE", "SALDAÑA", "SALDIVAR", "SALINAS", "SAMANIEGO", "SAMARRIPA", "SANABRIA", "SANCHEZ", "SANDOVAL", "SANGUINO", "SANTILLAN", "SANTISBAIS", "SAUCEDO", "SEGOVIA", "SEGOVIANO", "SEGURA", "SERDA", "SERENO", "SERNA", "SERRANO", "SERRATO",  "SERRATOS", "SERVIN", "SIFUENTES", "SIGALA", "SILVA", "SOBERANIS", "SOLEDAD", "SOLIS", "SOLORZA", "SOLORZANO", "SORIA", "SORIANO", "SOSA", "SOTO", "SUAREZ", "SUÑIGA",
            "TABARES", "TABAREZ", "TAFOYA", "TAPIA", "TAPIAS", "TAPIAZ", "TARANGO", "TAVARES", "TAVAREZ", "TECPA", "TEJEDA", "TELLO", "TEMBLADOR", "TENORIO", "TEPETITLA", "TERAN", "TERRONES", "TOBAR", "TORAN", "TORRES", "TOSTADO", "TOVAR", "TRANCOSO", "TREJO", "TRILLO", "TRISTAN", "TRUJILLO",
            "ULLOA", "URBINA", "URQUIETA", "URZUA",
            "VALADEZ", "VALDERRAMA", "VALDES", "VALDEZ", "VALDIVIA", "VALDVIA", "VALENCIA", "VALERIO", "VALLE", "VALLEJO", "VALTIERRA", "VARELA", "VARELAS", "VARGAS", "VARILLAS", "VASQUEZ", "VAZQUEZ", "VEGA", "VELASCO", "VELAZQUEZ", "VELETA", "VELEZ", "VELOS", "VELOZ", "VENTURA", "VERA", "VERDIN", "VICENCIO", "VICENSIO", "VIDAL", "VIDRIO", "VIERA", "VIGIL", "VILLA", "VILLAFUERTE", "VILLAGRAN", "VILLAGRANA", "VILLALOBOS", "VILLALPANDO", "VILLANUEVA", "VILLASEÑOR", "VILLEGAS", "VILLELA", "VILLLALBOS", "VIRAMONTES", "VISCENCIO", "VIZCARRA",
            "YAÑEZ", "YEPEZ",
            "ZAMARRIPA", "ZAMARRIPAS", "ZAMBRANO", "ZAMORA", "ZAMRRIPA", "ZAPATA", "ZARAGOZA", "ZARATE", "ZAVALA", "ZERMEÑO", "ZIMBRON", "ZUNO", "ZUÑIGA"
        };

        /// <summary>
        ///     La lista de apellidos compuestos de dos palabras que comienzan con DE.
        /// </summary>
        private readonly IEnumerable<string> ApellidosDe = new HashSet<string>
        {
            "LEON", "LIRA", "LOZA", "LUNA", "SANTIAGO", "SANTOS"
        };

        /// <summary>
        ///     La lista de apellidos compuestos de tres palabras que comienzan con DE LA.
        /// </summary>
        private readonly IEnumerable<string> ApellidosDeLa = new HashSet<string>
        {
            "CERDA", "CRUZ", "MORA", "RIVA", "ROSA", "SIERRA", "TORRE"
        };

        /// <summary>
        ///     La lista de nombres.
        /// </summary>
        /// <remarks>Nombres de una sola palabra que no se confundan con algun apellido.</remarks>
        private readonly IEnumerable<string> Nombres = new HashSet<string>
        {
            "AARON", "ABEL", "ABELINA", "ABIGAIL", "ABILENE", "ABILIENE", "ABRAHAM", "ABRAM", "ABRIL", "ABUNDIO", "ADA", "ADALBERTO", "ADAN", "ADELA", "ADELAIDA", "ADELFO", "ADILENA", "ADILENE", "ADIRAN", "ADLEMI", "ADOLFO", "ADONAY", "ADRIAN", "ADRIANA", "AESTHER", "AGAPITA", "AGAPITO", "AGRIPINA", "AGSUTIN", "AGUSTIN", "AGUSTINA", "AGUSTINO", "AGUSTO", "AGUTISTNA", "AIDA", "AILYN", "ALAN", "ALANA", "ALBA", "ALBANELI", "ALBANO", "ALBERTA", "ALBERTO", "ALBINA", "ALCIA", "ALDAIR", "ALDO", "ALEAJNDRO", "ALEJADNRO", "ALEJANDRA", "ALEJANDRINA", "ALEJANDRO", "ALEONSO", "ALESSIA", "ALEX", "ALEXA", "ALEXANADER", "ALEXANDER", "ALEXANDRA", "ALEXANDRO", "ALEXIS", "ALFONSO", "ALFREDO", "ALI", "ALICIA", "ALINA", "ALISON", "ALIZETH", "ALLISON", "ALMA", "ALMAANGELICA", "ALONDRA", "ALONSO", "ALTAGRACIA", "ALVARO", "ALVINA", "ALYSON", "AMADA", "AMALIA", "AMARANTA", "AMBROSIO", "AMELIA", "AMERICA", "AMICAR", "AMPARO", "AMPELIA", "AMY", "ANA", "ANABEL", "ANACARMEN", "ANACLETO", "ANAHI", "ANAHY", "ANAI", "ANALIA", "ANALLELY", "ANAMARIA", "ANAN", "ANASTACIA", "ANASTACIO", "ANAYALI", "ANAYELI", "ANCELMA", "ANCLETO", "ANDERSON", "ANDRA", "ANDREA", "ANDRES", "ANDY", "ANECTO", "ANGELA", "ANGELICA", "ANGELINA", "ANGELITA", "ANGELO", "ANICETO", "ANITA", "ANOTNIO", "ANSELMA", "ANTELMA", "ANTELMO", "ANTHONY", "ANTOINE", "ANTOLIN", "ANTONI", "ANTONIA", "ANTONIO", "ANTONY", "APOLINAR", "APOLINARIA", "APOLONIA", "APOLONIO", "AQUETZALY", "AQUINA", "ARACELI", "ARACELY", "ARAMANDO", "ARANIA", "ARANZA", "ARASELI", "ARBELI", "ARCELIA", "ARELI", "ARELT", "ARELY", "ARGIMIRO", "ARIANA", "ARIOSTO", "ARISTEO", "ARIZTBE", "ARLED", "ARLET", "ARLETH", "ARLETTE", "ARLHET", "ARMANDO", "ARMIDAANGELICA", "ARNIGIO", "ARNULFO", "ARTEMIO", "ARTURO", "ARULFO", "ASAEL", "ASCENCION", "ASHELY", "ASHLEY", "ASHLI", "ASHLY", "ASUNCION", "ATAULFO", "AUDELIA", "AUDOLIANA", "AURELIA", "AURELIANO", "AURELIO", "AURORA", "AUSTREBERTHA", "AUSUNCION", "AVILENE", "AXEL", "AYARI", "AYDA", "AZAREEL", "AZUCENA",
            "BEATRIZ", "BENJAMIN", "BERENICE", "BERTA", "BERTHA", "BRENDA",
            "CARLOS", "CARMEN", "CESAR", "CECILIA", "CHRISTIAN", "CLAUDIA", "CONCEPCION", "CRISTINA",
            "DAVID", "DANIEL", "DENISSE", "DIANA",
            "EDUARDO", "ELIZABETH", "EMMANUEL", "ENRIQUE", "ESMERALDA",  "ESPERANZA",
            "FELICITAS", "FELIPE", "FERNANDO", "FRANCISCA", "FRANCISCO",
            "GABRIEL", "GABRIELA", "GERARDO", "GLORIA",  "GRACIELA", "GUADALUPE", "GUILLERMINA", "GUILLERMO", "GUSTAVO",
            "IGNACIO", "IRENE", "IRMA",
            "JAQUELINE", "JAVIER", "JESSICA", "JESUS", "JONATHAN", "JORGE", "JOSE", "JOSEFINA", "JUAN", "JUANA",
            "KEVIN",
            "LETICIA", "LILIANA", "LORENA", "LUIS",
            "MA", "MA.", "MANUEL", "MARIA", "MARICELA", "MARGARITA", "MARGARITO", "MARIA", "MARIANA", "MARLEN", "MARTA", "MARTHA", "MARTINA", "MERCEDES", "MIGUEL", "MIRIAM", "MONICA", "MOISES",
            "NANCY", "NATALIA", "NAYELI",
            "OBDULIA", "OCTAVIO", "ODALIS", "ODAVIA", "OFELIA", "OFILIA", "OFLEIA", "OLEGARIO", "OLGA", "OLI0MPIA", "OLIBIER", "OLIMOPIA", "OLIMPIA", "OLIVER", "OLIVIA", "OMAR", "ORACIO", "ORALIA", "ORLANDO", "OSCAR", "OSGAR", "OSIEL", "OSMARA", "OSTI", "OSVALDO", "OSWALDO", "OTHON", "OTONIEL", "OWEN",
            "PATRICIA", "PAULO", "PEDRO",
            "RAMON", "RAMONA", "RAUL", "RAQUEL", "RICARDO", "RICARDO", "ROBERTO", "ROSA", "ROSARIO", "RUBEN",
            "SALVADOR", "SAMUEL", "SANDRA", "SANTIAGO", "SARA", "SAUL", "SERGIO", "SILVIA", "SILVESTRE",  "SOCORRO", "SUSANA",
            "TERESA", "TERESITA",
            "VERONICA", "VICTOR", "VICTORIA", "VICTORIA",
            "YOLANDA",
            "QUETZALLI"
        };

        /// <summary>
        ///     La lista de nombres compuestos de tres palabras que comienzan con DE LA.
        /// </summary>
        private readonly IEnumerable<string> NombresDeLa = new HashSet<string>
        {
            "ASCENCION", "ASUNCION", "CRUZ", "LUZ", "MERCED", "PAZ", "SALUD", "TORRE", "TRINIDAD"
        };

        /// <summary>
        ///     La lista de nombres compuestos de tres palabras que comienzan con DE LOS.
        /// </summary>
        private readonly IEnumerable<string> NombresDeLos = new HashSet<string>
        {
            "ANGELES", "DOLORES", "MILAGROS", "REMEDIOS"
        };

        /// <summary>
        ///     Aquellos nombres que contienen solo 2 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres2Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 3 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres3Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 4 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres4Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 5 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres5Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 6 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres6Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 7 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres7Palabras = new HashSet<string>();

        /// <summary>
        ///     Aquellos nombres que contienen solo 8 palabras.
        /// </summary>
        private readonly HashSet<string> Nombres8Palabras = new HashSet<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SeparadorNombres"/> class.
        /// </summary>
        /// <param name="nombres">
        /// The nombres.
        /// </param>
        public SeparadorNombres(IEnumerable<string> nombres)
        {
            this.Separar(nombres);
        }

        /// <summary>
        ///     Separa una lista de nombres dependiendo el numero de palabras que contenga.
        /// </summary>
        /// <param name="nombres">La lista de nombres.</param>
        private void Separar(IEnumerable<string> nombres)
        {
            // Separar los nombres por numero de palabras
            foreach (var nombre in nombres)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ').Length;

                switch (n)
                {
                    case 2:
                        this.Nombres2Palabras.Add(nombre);
                        break;
                    case 3:
                        this.Nombres3Palabras.Add(nombre);
                        break;
                    case 4:
                        this.Nombres4Palabras.Add(nombre);
                        break;
                    case 5:
                        this.Nombres5Palabras.Add(nombre);
                        break;
                    case 6:
                        this.Nombres6Palabras.Add(nombre);
                        break;
                    case 7:
                        this.Nombres7Palabras.Add(nombre);
                        break;
                    case 8:
                        this.Nombres8Palabras.Add(nombre);
                        break;
                    default:
                        this.Indefinidos.Add(nombre);
                        break;
                }
            }

            this.Palabras2();
            this.Palabras3();
            this.Palabras4();
            this.Palabras5();
            this.Palabras6();
            // this.Palabras7();
            // this.Palabras8();
        }

        private void Palabras2()
        {
            foreach (var nombre in this.Nombres2Palabras)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ');

                // REBECA GONZALEZ
                if (this.Criterios("2-01", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = n[0], Paterno = n[1], Materno = null });
                    continue;
                }

                // Indefinidos
                this.Indefinidos.Add(nombre);
            }
        }

        private void Palabras3()
        {
            foreach (var nombre in this.Nombres3Palabras)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ');

                // ROBERTO FRANCO HERNANDEZ
                if (this.Criterios("3-01", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = n[0], Paterno = n[1], Materno = n[2] });
                    continue;
                }

                // JUAN MANUEL ROMO
                if (this.Criterios("3-02", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} {n[1]}", Paterno = n[2], Materno = null });
                    continue;
                }

                // Indefinidos
                this.Indefinidos.Add(nombre);
            }
        }

        private void Palabras4()
        {
            foreach (var nombre in this.Nombres4Palabras)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ');

                // RICARDO JAVIER FRANCO VELAZQUEZ
                if (this.Criterios("4-01", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} {n[1]}", Paterno = n[2], Materno = n[3] });
                    continue;
                }

                // Indefinidos
                this.Indefinidos.Add(nombre);
            }
        }

        private void Palabras5()
        {
            foreach (var nombre in this.Nombres5Palabras)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ');

                // ALBERTO DE SANTOS DE LEON
                if (this.Criterios("5-01", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = n[0], Paterno = $"DE {n[2]}", Materno = $"DE {n[4]}" });
                    continue;
                }

                // RICARDO AGUILERA DE LA TORRE
                if (this.Criterios("5-02", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = n[0], Paterno = n[1], Materno = $"DE LA {n[4]}" });
                    continue;
                }

                // MA DE LA LUZ HUIZAR
                if (this.Criterios("5-03", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} DE LA {n[3]}", Paterno = n[4], Materno = null });
                    continue;
                }

                // SANTIAGO DE JESUS ZAPATA GONZALEZ
                if (this.Criterios("5-04", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} DE JESUS", Paterno = n[3], Materno = n[4] });
                    continue;
                }

                // MARIA DOLORES DE LUNA RAMIREZ
                if (this.Criterios("5-05", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} {n[1]}", Paterno = $"DE {n[3]}", Materno = n[4] });
                    continue;
                }

                // Indefinidos
                this.Indefinidos.Add(nombre);
            }
        }

        private void Palabras6()
        {
            foreach (var nombre in this.Nombres6Palabras)
            {
                var n = nombre.Trim().Replace("  ", " ").ToUpper().Split(' ');

                // RICARDO JAVIER DE LA CRUZ VELAZQUEZ
                if (this.Criterios("6-01", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} {n[1]}", Paterno = $"DE LA {n[4]}", Materno = n[5] });
                    continue;
                }

                // MARIA DE LOS ANGELES SOLORZANO GARCIA
                if (this.Criterios("6-02", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} DE LOS {n[3]}", Paterno = n[4], Materno = n[5] });
                    continue;
                }

                // MARIA DE LA CRUZ GUZMAN PEREZ
                if (this.Criterios("6-03", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} DE LA {n[3]}", Paterno = n[4], Materno = n[5] });
                    continue;
                }

                // MA. DEL SAN JUAN GARCIA LOPEZ
                if (this.Criterios("6-04", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} DEL SAN JUAN", Paterno = n[4], Materno = n[5] });
                    continue;
                }

                // CLAUDIA DE ANDA DE LA TORRE
                if (this.Criterios("6-05", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = n[0], Paterno = $"DE {n[2]}", Materno = $"DE LA {n[5]}" });
                    continue;
                }

                // CELSA ESTEFANIA MARQUEZ DE LA TORRE
                if (this.Criterios("6-06", n))
                {
                    this.Personas.Add(nombre, new Persona { Nombres = $"{n[0]} {n[1]}", Paterno = n[2], Materno = $"DE LA {n[5]}" });
                    continue;
                }

                // Indefinidos
                this.Indefinidos.Add(nombre);
            }
        }

        private void Palabras7()
        {
            throw new System.NotImplementedException();
        }

        private void Palabras8()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Determina si una lista de palabras cumple con un criterio en espesifico.
        /// </summary>
        /// <param name="criterioId"> ID del criterio.</param>
        /// <param name="palabras"> Las palabras.</param>
        /// <returns> Verdadero si la lista de palabras cumple con el criterio dado.</returns>
        private bool Criterios(string criterioId, IReadOnlyList<string> palabras)
        {
            switch (criterioId)
            {
                case "2-01":
                    // REBECA GONZALEZ
                    return this.Nombres.Contains(palabras[0]) && this.Apellidos.Contains(palabras[1]);
                case "3-01":
                    // ROBERTO FRANCO HERNANDEZ
                    return this.Apellidos.Contains(palabras[1]) && this.Apellidos.Contains(palabras[2]);
                case "3-02":
                    // JUAN MANUEL ROMO
                    return this.Nombres.Contains(palabras[0]) && this.Nombres.Contains(palabras[1]) && this.Apellidos.Contains(palabras[2]);
                case "4-01":
                    // RICARDO JAVIER FRANCO VELAZQUEZ
                    return this.Nombres.Contains(palabras[0]) && this.Nombres.Contains(palabras[1])
                           && this.Apellidos.Contains(palabras[2]) && this.Apellidos.Contains(palabras[3]);
                case "5-01":
                    // ALBERTO DE SANTOS DE LEON
                    return palabras[1] == "DE" && palabras[3] == "DE"
                           && this.ApellidosDe.Contains(palabras[2]) && this.ApellidosDe.Contains(palabras[4]);
                case "5-02":
                    // RICARDO AGUILERA DE LA TORRE
                    return this.Apellidos.Contains(palabras[1]) && palabras[2] == "DE" && palabras[3] == "LA"
                           && this.ApellidosDeLa.Contains(palabras[4]);
                case "5-03":
                    // MA DE LA LUZ HUIZAR
                    return palabras[1] == "DE" && palabras[2] == "LA"
                           && this.NombresDeLa.Contains(palabras[3]) && this.Apellidos.Contains(palabras[4]);
                case "5-04":
                    // SANTIAGO DE JESUS ZAPATA GONZALEZ
                    return palabras[1] == "DE" && palabras[2] == "JESUS"
                        && this.Apellidos.Contains(palabras[3]) && this.Apellidos.Contains(palabras[4]);
                case "5-05":
                    // MARIA DOLORES DE LUNA RAMIREZ
                    return palabras[2] == "DE" && this.ApellidosDe.Contains(palabras[3]);
                case "6-01":
                    // RICARDO JAVIER DE LA CRUZ VELAZQUEZ
                    return palabras[2] == "DE" && palabras[3] == "LA" && this.ApellidosDeLa.Contains(palabras[4]);
                case "6-02":
                    // MARIA DE LOS ANGELES SOLORZANO GARCIA
                    return palabras[1] == "DE" && palabras[2] == "LOS" && this.NombresDeLos.Contains(palabras[3]);
                case "6-03":
                    // MARIA DE LA CRUZ GUZMAN PEREZ
                    return palabras[1] == "DE" && palabras[2] == "LA" && this.NombresDeLa.Contains(palabras[3])
                            && this.Apellidos.Contains(palabras[4]) && this.Apellidos.Contains(palabras[5]);
                case "6-04":
                    // MA. DEL SAN JUAN GARCIA LOPEZ
                    return palabras[1] == "DEL" && palabras[2] == "SAN" && palabras[3] == "JUAN"
                            && this.Apellidos.Contains(palabras[4]) && this.Apellidos.Contains(palabras[5]);
                case "6-05":
                    // CLAUDIA DE ANDA DE LA TORRE
                    return palabras[1] == "DE" && this.ApellidosDe.Contains(palabras[2]) && palabras[3] == "DE" && palabras[4] == "LA"
                           && this.ApellidosDeLa.Contains(palabras[5]);
                case "6-06":
                    // CELSA ESTEFANIA MARQUEZ DE LA TORRE
                    return this.Apellidos.Contains(palabras[2]) && palabras[3] == "DE" && palabras[4] == "LA" && this.ApellidosDeLa.Contains(palabras[5]);
                default:
                    return false;
            }
        }
    }
}
