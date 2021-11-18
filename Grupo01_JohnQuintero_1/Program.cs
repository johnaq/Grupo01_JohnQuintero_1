/*
 * John Alexander Quintero Mesa
 * Grupo 01
 * 
 * Una represa se utiliza para generar energía eléctrica y para el control del flujo de aguas. La 
 * capacidad de la represa es 4 unidades e iniciará el mes con 1 unidad La función de
 * probabilidad de la cantidad de agua que fluye a la represa en el mes siguiente
 * 
 * ┌───────────────┬───────┬───────┬───────┬──────┐
 * │ Cantidad      │    0  │    1  │    2  │    3 │
 * │ Probabilidad  │ 0.15  │ 0.35  │ 0.30  │ 0.20 │
 * └───────────────┴───────┴───────┴───────┴──────┘
 * 
 * Si el agua en la represa excede la capacidad máxima, el agua sobrante se suelta a través del 
 * vertedero, que es un flujo libre. Para generar energía se requieren mensualmente dos unidades que 
 * se sueltan al final de cada mes. Si hay menos de dos unidades en la presa, se genera energía con el 
 * agua disponible, es decir, se suelta toda la cantidad de agua que exista.
 * 
 * Realice una simulación del proceso mediante un pseudocodigo y determine 
 * A) ¿Cuántas unidades se tirarían al vertedero por exceso de capacidad durante los próximos 
 *    15 años? ¿Qué propondría según el resultado obtenido?
 * B) ¿Cuántas veces se tuvo que generar energía con menos de dos unidades durante el mismo 
 *    periodo de 15 años?
 */

Random random = new();
int nMeses = 180; //15 años
int cantidadExceso = 0;
int mesesMenos2Unidades = 0;
int cantAgua;
double probabilidad;

Represa();
ImprimirResultados();
Console.ReadLine();

void Represa()
{
    for (int i = 0; i < nMeses; i++)
    {
        cantAgua = 1;
        probabilidad = random.NextDouble();

        if(probabilidad <= 0.15d)
            cantAgua += 0;
        else if(probabilidad <= 0.5d)
            cantAgua += 1;
        else if (probabilidad <= 0.8d)
            cantAgua += 2;
        else
            cantAgua += 3;

        cantidadExceso += CalcularExceso(cantAgua);

        ContadorMenos2Unidades(cantAgua);

        Console.WriteLine($"Mes {i + 1}, Unidades: {cantAgua}, Exceso {CalcularExceso(cantAgua)}");
    }
}

int CalcularExceso(int cantAgua)
{
    int resultado = 0;
    if (cantAgua > 2)
        resultado = cantAgua - 2;

    return resultado;
}

void ContadorMenos2Unidades(int cantAgua)
{
    if (cantAgua < 2)
        mesesMenos2Unidades++;
}

void ImprimirResultados(){
    Console.WriteLine();
    Console.WriteLine($"Unidades que se tirarían por exceso: {cantidadExceso}");
    Console.WriteLine($"Veces que se generó energía con menos de dos unidades: {mesesMenos2Unidades}");
}