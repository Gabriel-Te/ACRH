public class TelemetryData
{
    // === Dados Básicos ===
    public int IdPacote { get; set; }
    public float Acelerador { get; set; }
    public float Freio { get; set; }
    public float Combustivel { get; set; }
    public int Marcha { get; set; }
    public int Rpm { get; set; }
    public float AnguloEsterco { get; set; }
    public float VelocidadeKmh { get; set; }

    // === Sistemas e Auxílios ===
    public float Drs { get; set; }
    public float ControleTracao { get; set; }
    public float Rumo { get; set; }     // Heading
    public float Arfagem { get; set; }   // Pitch
    public float Rolagem { get; set; }   // Roll
    public float AlturaCentroGravidade { get; set; }

    public int QtdPneusForaPista { get; set; }
    public int LimitadorPitStopLigado { get; set; }
    public float Abs { get; set; }
    public float CargaKers { get; set; }
    public float EntradaKers { get; set; }
    public int CambioAutomaticoLigado { get; set; }

    // === Ambiente e Motor ===
    public float Turbo { get; set; }
    public float Lastro { get; set; }
    public float DensidadeAr { get; set; }
    public float TemperaturaAr { get; set; }
    public float TemperaturaPista { get; set; }
    public float FeedbackForcaFinal { get; set; } // FFB
    public float MedidorPerformance { get; set; }
    public int FreioMotor { get; set; }
    public int NivelRecuperacaoErs { get; set; }
    public int NivelPotenciaErs { get; set; }
    public int CarregamentoCalorErs { get; set; }
    public int ErsEstaCarregando { get; set; }
    public float KersAtualKJ { get; set; }
    public int DrsDisponivel { get; set; }
    public int DrsAtivado { get; set; }
    public float Embreagem { get; set; }
    public int ControladoPelaIA { get; set; }
    public float BalancoFreio { get; set; }

    // === Vetores e Arrays (Rodas/Posição) ===
    public float[] VelocidadeVetor { get; set; } = new float[3];
    public float[] ForcaG { get; set; } = new float[3];
    public float[] DeslizeRoda { get; set; } = new float[4];
    public float[] CargaRoda { get; set; } = new float[4];
    public float[] PressaoPneus { get; set; } = new float[4];
    public float[] VelocidadeAngularRoda { get; set; } = new float[4];
    public float[] DesgastePneu { get; set; } = new float[4];
    public float[] NivelSujeiraPneu { get; set; } = new float[4];
    public float[] TempNucleoPneu { get; set; } = new float[4];
    public float[] CambagemRad { get; set; } = new float[4];
    public float[] CursoSuspensao { get; set; } = new float[4];
    public float[] DanoCarro { get; set; } = new float[5];
    public float[] AlturaSolo { get; set; } = new float[2];
    public float[] VelocidadeAngularLocal { get; set; } = new float[3];
    public float[] TempFreio { get; set; } = new float[4];
    public float[] TempPneuInterna { get; set; } = new float[4];
    public float[] TempPneuMeio { get; set; } = new float[4];
    public float[] TempPneuExterna { get; set; } = new float[4];
    public float[] PontoContatoPneu { get; set; } = new float[4];
    public float[] NormalContatoPneu { get; set; } = new float[4];
    public float[] DirecaoContatoPneu { get; set; } = new float[4];
    public float[] VelocidadeLocal { get; set; } = new float[3];
}