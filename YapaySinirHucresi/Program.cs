double[][] verileriOlustur() 
{   
    //burada eğitimde kullanılacak olan veriler olusturuldu.
    double[][] veriler = new double[21][];
    veriler[0] = new double[] {7.6,11,77};
    veriler[1] = new double[] { 8, 10, 70 };
    veriler[2] = new double[] { 6.6, 8, 55 };
    veriler[3] = new double[] { 8.4, 10, 78 };
    veriler[4] = new double[] { 8.8, 12, 95 };
    veriler[5] = new double[] { 7.2, 10,67 };
    veriler[6] = new double[] { 8.1, 11, 80 };
    veriler[7] = new double[] { 9.5, 9, 87 };
    veriler[8] = new double[] { 7.3, 9, 60 };
    veriler[9] = new double[] { 8.9, 11, 88 };
    veriler[10] = new double[] { 7.5, 11, 72 };
    veriler[11] = new double[] { 7.6, 9, 58 };
    veriler[12] = new double[] { 7.9, 10, 70 };
    veriler[13] = new double[] { 8, 10, 76 };
    veriler[14] = new double[] { 7.2, 9, 58 };
    veriler[15] = new double[] { 8.8, 10, 81 };
    veriler[16] = new double[] { 7.6, 11, 74 };
    veriler[17] = new double[] { 7.5, 10, 67 };
    veriler[18] = new double[] { 9, 10, 82 };
    veriler[19] = new double[] { 7.7, 9, 62 };
    veriler[20] = new double[] { 8.1, 11, 82 };

    return veriler;
}

void egitim(Neuron neuron,double[][] veriler,double lamda,int epoch) {
    
    //bu metotta eğitilecek olan neuron nesnesi, kullanılacak veriler ve lambda ile epok değerleri alınarak eğitim yapılıyor.
    for (int devirNo = 1; devirNo <= epoch; devirNo++)
    {   
        //döngü 10 epok boyunca dönecek.
        for(int satirIndex = 0; satirIndex < veriler.Length; satirIndex++)
        {   
            //buradaki döngüde veriler üstünde 1 kez dönerek eğitim işlemi yapılıyor.
            double calismaSuresi = veriler[satirIndex][0] / 10;
            double derseKatilma = veriler[satirIndex][1] / 15;
            double target = veriler[satirIndex][2] / 100;
            double output = neuron.ciktiHesaplama(calismaSuresi, derseKatilma);

            double tempWeight1 = 0;
            double tempWeight2 = 0;

            tempWeight1 = neuron.getWeight1() + lamda * (target - output) * calismaSuresi;
            tempWeight2 = neuron.getWeight2() + lamda * (target - output) * derseKatilma;

            neuron.setWeight1(tempWeight1);
            neuron.setWeight2(tempWeight2);
        }
    }
}

void modeliTestEtme1(Neuron neuron, double[][] veriler)
{   
    //bu metotta modeli eğitilen veriler kullanılarak metotun verdiği sonuclar ölçülüyor.
    double[][] denemeTablosu = new double[veriler.Length][];
    for(int i = 0; i < veriler.Length; i++)
    {
        denemeTablosu[i] = new double[4];
    }

    for(int satirIndex = 0; satirIndex < veriler.Length; satirIndex++)
    {   
        //burada veriler ve verilerle üretilen çıktı ile test sonuçları denemetablosuna yazdırılıyor.
        double calismaSuresi = veriler[satirIndex][0]/10;
        double derseKatilim = veriler[satirIndex][1]/15;
        double target = veriler[satirIndex][2]/100;
        double output = neuron.ciktiHesaplama(calismaSuresi, derseKatilim);

        denemeTablosu[satirIndex][0] = calismaSuresi;
        denemeTablosu[satirIndex][1] = derseKatilim;
        denemeTablosu[satirIndex][2] = target;
        denemeTablosu[satirIndex][3] = output;
    }

    for(int satirIndex = 0;satirIndex < denemeTablosu.Length; satirIndex++)
    {
        //test sonuclarının yazdırılmasını sağlayan kısım.
        Console.WriteLine(Math.Round(denemeTablosu[satirIndex][0],4) +"\t"+Math.Round(denemeTablosu[satirIndex][1],4)+"\t"+Math.Round(denemeTablosu[satirIndex][2],4)+"\t"+Math.Round(denemeTablosu[satirIndex][3],4));
    }

    //burada mse değri hesaplanıyor.
    double karelerToplami = 0;
    for (int satirIndex = 0; satirIndex < denemeTablosu.Length; satirIndex++) 
    {
        karelerToplami += Math.Pow((denemeTablosu[satirIndex][2] - denemeTablosu[satirIndex][3]),2);
    }
    double MSE = karelerToplami/ denemeTablosu.Length;

    Console.WriteLine("Mean square error değeri: "+MSE);
}

void modeliTestEtme2(Neuron neuron) 
{
    //Eğitim verileri dışında farklı 5 tane girdi verisi oluşturarak modele tahminleme yaptıran metot.
    double[][] testVerileri = new double[5][];
    for (int i = 0; i < 5; i++) 
    {
        testVerileri[i] = new double[3];
    }
    //ders calisma sureleri olusturuldu.
    testVerileri[0][0] = 6.4;
    testVerileri[1][0] = 9.7;
    testVerileri[2][0] = 12.1;
    testVerileri[3][0] = 6.7;
    testVerileri[4][0] = 3.1;
    //derse katılım değerleri olusturuldu.
    testVerileri[0][1] = 5;
    testVerileri[1][1] = 7;
    testVerileri[2][1] = 11;
    testVerileri[3][1] = 15;
    testVerileri[4][1] = 9;

    for (int i = 0; i < 5; i++) 
    {   
        //verilerle tahmini output hesabı yapılıyor.
        double calismaSaati = testVerileri[i][0]/10;
        double devamSuresi = testVerileri[i][1]/15;
        double output = neuron.ciktiHesaplama(calismaSaati, devamSuresi);
        testVerileri[i][2] = output;
    }

    Console.WriteLine("Çalışma Saati   Derse Katılım    Beklenen Çıktı");
    for (int i = 0; i < 5; i++) 
    {
        Console.WriteLine(testVerileri[i][0] + "\t\t" + testVerileri[i][1] + "\t\t " + testVerileri[i][2]);
    }
}

double mseHesaplayici(Neuron neuron, double[][] veriler) 
{   
    //burada verilerin saklanması için jaggedArray oluşturuluyor.
    double[][] denemeTablosu = new double[veriler.Length][];
    for (int i = 0; i < veriler.Length; i++)
    {
        denemeTablosu[i] = new double[4];
    }

    //bu döngüde deneme sırasında kullanılan veriler ve output arraya yazdırılıyor.
    for (int satirIndex = 0; satirIndex < veriler.Length; satirIndex++)
    {
        double calismaSuresi = veriler[satirIndex][0]/10;
        double derseKatilim = veriler[satirIndex][1]/15;
        double target = veriler[satirIndex][2]/100;
        double output = neuron.ciktiHesaplama(calismaSuresi, derseKatilim);

        denemeTablosu[satirIndex][0] = calismaSuresi;
        denemeTablosu[satirIndex][1] = derseKatilim;
        denemeTablosu[satirIndex][2] = target;
        denemeTablosu[satirIndex][3] = output;
    }

    //elde edilen veriler kullanılarak mse değeri hesaplanıyor.
    double karelerToplami = 0;
    for (int satirIndex = 0; satirIndex < denemeTablosu.Length; satirIndex++)
    {
        karelerToplami += Math.Pow((denemeTablosu[satirIndex][2] - denemeTablosu[satirIndex][3]), 2);
    }
    double MSE = karelerToplami / denemeTablosu.Length;

    return MSE;
}

void MseMatrisOlusturma(double[][] veriler) 
{
    //lambda değerleri 0.01 0.025 0.05 olarak ve epok değerleri 10.50.100 olarak kullanıldığında ortaya çıkan MSE değerlerinin matris şeklinde tutulması
    double[] lambdalar = { 0.01, 0.025, 0.05 };
    int[] epoklar = { 10, 50, 100};

    //burada mse değerlerinin matris şeklinde tutulması için jaggedArray olusturuluyor.
    double[][] MseDegerleri = new double[epoklar.Length][];
    for (int i = 0; i < epoklar.Length; i++) 
    {
        MseDegerleri[i] = new double[3];
    }

    for (int satirIndex = 0; satirIndex <= 2; satirIndex++) 
    { 
        for(int sutunIndex  = 0; sutunIndex <= 2;sutunIndex++) 
        {   
            //buradaki iç içe döngüler ile bütün epok ve lamda kombinasyonları ile nöron eğitimi yapılıp sonucunda olusan mse değerleri matrise yazılıyor.
            Neuron testNeuronu = new Neuron();
            egitim(testNeuronu, veriler, lambdalar[sutunIndex], epoklar[satirIndex]);
            double mse = mseHesaplayici(testNeuronu, veriler);
            MseDegerleri[satirIndex][sutunIndex] = mse;
        }
    }

    //burada sonuc matrisinin yazdırılma işlemi gerçekleşiyor.
    Console.WriteLine("\t" + lambdalar[0] + "\t"+lambdalar[1]+"\t" +lambdalar[2]);
    for (int satirIndex = 0; satirIndex <= 2; satirIndex++) { 
   
        Console.WriteLine(epoklar[satirIndex] + "\t" + MseDegerleri[satirIndex][0]+"\t"+ MseDegerleri[satirIndex][1] + "\t" + MseDegerleri[satirIndex][2]);
    }
}

string devam = "e";
double[][] veriler = verileriOlustur();

while (devam == "e" || devam == "E")
{
    Console.WriteLine("1 - lambda değeri 0.05 epok değeri 10 olacak şekilde eğitimin gerçekleşip eğitim için kullanılan verilerle test işlemi ve mse değerinin hesaplanması\n" +
        "2 - modelin görmediği 5 yeni veri ile modelin test edilmesi işlemi\n" +
        "3 - 10,50,100 epok değerleri ve 0.01 0.025 0.05 lambda değerleri ile eğitim sonucu oluşan mse değerleri matrisinin görüntülenmesi.");
    Console.Write("Seçeneğiniz:");
    string input = Console.ReadLine();
    int secim = Convert.ToInt32(input);
    if(secim == 1)
    {
        Neuron neuron = new Neuron();
        egitim(neuron,veriler, 0.05, 10);
        modeliTestEtme1(neuron, veriler);
    }
    else if(secim == 2)
    {
        Neuron neuron = new Neuron();
        egitim(neuron, veriler, 0.05, 10);
        modeliTestEtme2(neuron);
    }else if(secim == 3)
    {
        MseMatrisOlusturma(veriler);
    }

    Console.Write("Devam edilsin mi?(e/E)");
    devam = Console.ReadLine();
}
