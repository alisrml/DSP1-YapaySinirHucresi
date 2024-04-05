public class Neuron
{
    double weight1;
    double weight2;

    public Neuron()
    {
        //Random sınıfı ile rastgele ağırlıklar atanıyor.
        Random random = new Random();
        weight1 = random.NextDouble();
        weight2 = random.NextDouble();

    }

    public double ciktiHesaplama(double calismaSuresi,double derseKatilim)
    {   
        //nörona verilen girdiler kullanılarak output değeri hesaplanıyor.
        double output = calismaSuresi*weight1 + derseKatilim*weight2;
        return output;
    }

    public double getWeight1() { return weight1; }
    public double getWeight2() { return weight2; }
    public void setWeight1(double weight) { weight1 = weight; }
    public void setWeight2(double weight) { weight2 = weight; }

}
