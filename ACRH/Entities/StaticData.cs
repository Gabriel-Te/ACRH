namespace ACRH.Entities
{
    public class StaticData
    {
        // === Informações Básicas e Jogador ===
        public char[] VersaoMemoriaCompartilhada { get; set; } = new char[15];

        public char[] VersaoAssettoCorsa { get; set; } = new char[15];

        public char[] ModeloCarro { get; set; } = new char[33];

        public char[] Pista { get; set; } = new char[33];


        public char[] NomeJogador { get; set; } = new char[33];
        public int NomeJogadorLen { get; set; }

        public char[] SobrenomeJogador { get; set; } = new char[33];
        public int SobrenomeJogadorLen { get; set; }

        public char[] ApelidoJogador { get; set; } = new char[33];
        public int ApelidoJogadorLen { get; set; }

        public int NumeroSessoes { get; set; }
        public int NumeroCarros { get; set; }

        public int QuantidadeSetores { get; set; }

        // === Especificações e Limites do Veículo ===
        public float TorqueMaximo { get; set; }
        public float PotenciaMaxima { get; set; }
        public int RpmMaximo { get; set; }
        public float CombustivelMaximo { get; set; }
        public float PressaoMaximaTurbo { get; set; }
        public int QtdConfiguracoesFreioMotor { get; set; }

        // === Sistemas Híbridos (KERS/ERS) ===
        public float EnergiaMaximaKersJ { get; set; }
        public float EnergiaMaximaErsJ { get; set; }
        public int PossuiDRS { get; set; }
        public int PossuiERS { get; set; }
        public int PossuiKERS { get; set; }
        public int QtdControladoresPotenciaErs { get; set; }

        // === Arrays de Suspensão e Pneus ===
        public float[] CursoMaximoSuspensao { get; set; } = new float[4];
        public float[] RaioPneu { get; set; } = new float[4];

        // === Regras, Assistências e Danos ===
        public int PenalidadesAtivadas { get; set; }
        public float TaxaConsumoCombustivel { get; set; }
        public float TaxaDesgastePneus { get; set; }
        public float TaxaDanoMecanico { get; set; }
        public int CobertoresPneuPermitidos { get; set; }
        public float AuxilioEstabilidade { get; set; }
        public int EmbreagemAutomatica { get; set; }
        public int PontaTacoAutomatico { get; set; } // AutoBlip

        // === Pista e Janela de Corrida ===
        public float ComprimentoPista { get; set; }
        public char[] ConfiguracaoPista { get; set; } = new char[33];
        public int ConfiguracaoPistaLen { get; set; }
        public int CorridaPorTempo { get; set; }
        public int PossuiVoltaExtra { get; set; }
        public char[] SkinCarro { get; set; } = new char[33];
        public int SkinCarroLen { get; set; }
        public int PosicoesGridInvertido { get; set; }
        public int InicioJanelaPit { get; set; }
        public int FimJanelaPit { get; set; }

        public static string ToManagedString(char[] buffer, int length)
        {
            if (buffer == null) return string.Empty;
            if (length <= 0) return string.Empty;
            return new string(buffer, 0, length);
        }
    }
}