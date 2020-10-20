using Maps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Data
{
    public class DbInitializer
    {
        public static void Initialize(TransmissionContext context)
        {
            context.Database.EnsureCreated();
            if (!context.RatedVoltage.Any())
            {
                var RatedVoltages = new RatedVoltage[]
                {
                    new RatedVoltage {Name = "Низковольтные (до 1 кВ) линии"},
                   new RatedVoltage {Name = "Высоковольтные линии среднего (3–35кВ) напряжения"},
                    new RatedVoltage {Name = "Высоковольтные линии высокого (110–220 кВ) напряжения"},
                    new RatedVoltage {Name = "Высоковольтные линии сверхвысокого (330–750 кВ) напряжения"},
                    new RatedVoltage {Name = "Высоковольтные линии  ультравысокого (св. 1000 кВ) напряжения"}
                };
                foreach (RatedVoltage b in RatedVoltages)
                {
                    context.RatedVoltage.Add(b);
                }
                context.SaveChanges();
            }

            if (!context.TypeOfCurrent.Any())
            {
                var TypesOfCurrent = new TypeOfCurrent[]
                {
                    new TypeOfCurrent {Name = "Линии постоянного тока"},
                    new TypeOfCurrent {Name = "Линии трёхфазного переменного тока"},
                    new TypeOfCurrent {Name = "ЛЭП многофазного переменного тока"}
                };
                foreach (TypeOfCurrent b in TypesOfCurrent)
                {
                    context.TypeOfCurrent.Add(b);
                }
                context.SaveChanges();
            }
            if (!context.ParallelCircuits.Any())
            {
                var ParallelCircuits = new ParallelCircuits[]
                {
                    new ParallelCircuits {Name = "Одноцепные"},
                    new ParallelCircuits {Name = "Двухцепные"},
                    new ParallelCircuits {Name = "Многоцепные"}

                };
                foreach (ParallelCircuits b in ParallelCircuits)
                {
                    context.ParallelCircuits.Add(b);
                }
                context.SaveChanges();
            }
            if (!context.Topology.Any())
            {
                var Topologies = new Topology[]
                {
                    new Topology {Name = "Pадиальные"},
                    new Topology {Name = "Магистральные "},
                    new Topology {Name = "Ответвления"}

                };
                foreach (Topology b in Topologies)
                {
                    context.Topology.Add(b);
                }
                context.SaveChanges();
            }

            if (!context.FunctionalPurpose.Any())
            {
                var FunctionalPurposes = new FunctionalPurpose[]
                {
                    new FunctionalPurpose {Name = "Pаспределительные"},
                    new FunctionalPurpose {Name = "Питающие"},
                    new FunctionalPurpose {Name = "Системообразующие и межсистемные"}

                };
                foreach (FunctionalPurpose b in FunctionalPurposes)
                {
                    context.FunctionalPurpose.Add(b);
                }
                context.SaveChanges();
            }
            if (!context.State.Any())
            {
                var States = new State[]
                {
                    new State {Name = "Используется"},
                    new State {Name = "Строится"},
                     new State {Name = "На реконструкции"},
                    new State {Name = "Не используется (заброшено)"},
                    new State {Name = "Снесено"},
                    new State {Name = "Изменение адреса"},
                    new State {Name = "Перестроено"},
                    new State {Name = "Изменение назначения"}
                };
                foreach (State b in States)
                {
                    context.State.Add(b);
                }
                context.SaveChanges();
            }

            if (!context.Project.Any())
            {
                var Projects = new Project[]
                {
                    new Project {Name = "Распределительные устройства и трансформаторные подстанции"},
                    new Project {Name = "407-3-46"}, //2
                    new Project {Name = "407-3-349.84"},//3
                    new Project {Name = "4-07-67"},//4
                    new Project {Name = "4-07-70"},//5
                    new Project {Name = "4-07-650"},//6
                    new Project {Name = "407-3-166"},//7
                    new Project {Name = "4-07-826"},//8
                    new Project {Name = "407-3-50"},//9
                    new Project {Name = "407-3-648.94"},//10
                    new Project {Name = "Неизв. проект трансформаторной подстанции (усл. лит. Р-50-1) (ІІ-я пол. 1950-х гг.)"},//11
                    new Project {Name = "507-7"},//12 
                    new Project {Name = "4-07-649"},//13
                };
                foreach (Project b in Projects)
                {
                    context.Project.Add(b);
                }
                context.SaveChanges();
            }
            if (!context.Builder.Any())
            {
                var Builders = new Builder[]
                {
                    new Builder {Name = "ОАО Ивгорэлектросеть"}, //1
                    new Builder {Name = "Трамвайное управление"},//2
                    new Builder {Name = "Снурилов А. Ф."},//3
                    new Builder {Name = "ИвГРЭС"},//4
                    new Builder {Name = "Трамвайно-троллейбусное управление"},//5
                };
                foreach (Builder b in Builders)
                {
                    context.Builder.Add(b);
                }
                context.SaveChanges();
            }


            if (!context.TransformerSubstation.Any())
            {
                var TransformerSubstations = new TransformerSubstation[]
                {
                    new TransformerSubstation {CoordinatesX = 56.99805856769737,CoordinatesY = 40.97873549999994, Address="Иваново, Улица 10 Августа, 12*", BuilderId= 1,Floors=1,YearFinish=2013,StateId=1,ProjectId=1, Name="ТП-1016"},
                    new TransformerSubstation {CoordinatesX = 56.99729856769538,CoordinatesY = 40.979804499999894, Address="Иваново, Улица 10 Августа, 16*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-139"},//builder null
                    new TransformerSubstation {CoordinatesX = 57.040427183263574,CoordinatesY = 40.99294250000001, Address="Иваново, 14-е почтовое отделение, ЗТП-22", BuilderId= 1,Floors=1,StateId=1,ProjectId=2, Name="ЗТП № 22"},
                    new TransformerSubstation {CoordinatesX = 57.040427183263574, CoordinatesY = 40.99294250000001, Address="Иваново, 14-е почтовое отделение, ЗТП-29", BuilderId= 1,Floors=1,StateId=1,ProjectId=3, Name="ЗТП №29"},
                    new TransformerSubstation {CoordinatesX = 57.01795256768802,CoordinatesY = 40.97224999999988, Address="Иваново, 2-я Сибирская улица, 9", BuilderId= 2,Floors=1,YearFinish=1958,StateId=1,ProjectId=1, Name="Тяговая подстанция №2"},
                    new TransformerSubstation {CoordinatesX = 56.98778106770112,CoordinatesY = 41.02445099999996, Address="Иваново, 3-я Сосневская улица, 139*", BuilderId=1,Floors=1,StateId=1,ProjectId=4, Name="ТП-536"},//builder null
                    new TransformerSubstation {CoordinatesX = 56.98569706769578, CoordinatesY = 40.96577299999995, Address="Иваново, 4-й Лётный переулок, 4*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП"},
                    new TransformerSubstation {CoordinatesX = 56.98689356772909, CoordinatesY = 41.03704549999995, Address="6-я Меланжевая улица, 1*", BuilderId= 1,Floors=1,YearFinish=1990,StateId=1,ProjectId=3, Name="ТП-236"},
                    new TransformerSubstation {CoordinatesX = 57.006137067687916, CoordinatesY = 40.981062499999986, Address="Иваново, Улица 8 Марта, 17*", BuilderId= 1,Floors=1,YearFinish=1960,StateId=1,ProjectId=5, Name="	ТП-379"},
                    new TransformerSubstation {CoordinatesX = 57.0065340676889, CoordinatesY = 40.987081, Address="Иваново, Улица 8 Марта, 31*", BuilderId= 1,Floors=1,StateId=1,ProjectId=6, Name="ТП-499"},
                    new TransformerSubstation {CoordinatesX = 56.99848056769845, CoordinatesY = 40.99438449999989, Address="Иваново, Улица III Интернационала, 39*", BuilderId= 3,Floors=1,YearFinish=1915,StateId=1,ProjectId=1, Name="ТП-18"},
                    new TransformerSubstation {CoordinatesX = 56.99739156769562, CoordinatesY = 40.989497499999906, Address="Иваново, Улица Арсения, 37*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-100"},
                    new TransformerSubstation {CoordinatesX = 57.0187270676598, CoordinatesY = 41.02039949999998, Address="Иваново, Улица Афанасьева, 9*", BuilderId=1 ,Floors=1,YearFinish=1955,StateId=1,ProjectId=1, Name="ТП-259"},
                    new TransformerSubstation {CoordinatesX = 57.00443466415509, CoordinatesY = 40.97446051356121, Address="Иваново, Улица Батурина, 6**", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-4"},
                    new TransformerSubstation {CoordinatesX = 56.989409067705346, CoordinatesY = 40.97055200000002, Address="Иваново, Улица Богдана Хмельницкого, 7*", BuilderId= 1,Floors=1,YearFinish=1985,StateId=1,ProjectId=3, Name="ТП-74"},
                    new TransformerSubstation {CoordinatesX = 56.99055206770829, CoordinatesY =40.99010849999998, Address="Иваново, Улица Бубнова, 40А", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-280"},
                    new TransformerSubstation {CoordinatesX = 56.99724013660895, CoordinatesY = 40.99585088657753, Address="Иваново, Улица Бубнова, 74*", BuilderId= 1,Floors=1,YearFinish=1963,StateId=1,ProjectId=5, Name="ТП-462"},
                    new TransformerSubstation {CoordinatesX = 56.997416333365976, CoordinatesY =40.99650295370688, Address="Иваново, Улица Бубнова, 76 стр. 1", BuilderId= 1,Floors=1,YearStart=1983,YearFinish=1883,StateId=1,ProjectId=7, Name="Насосная станция №4 и ТП-875"},
                    new TransformerSubstation {CoordinatesX = 56.98516884190515, CoordinatesY = 40.9985097077194, Address="Иваново, Варгинский переулок, 2", BuilderId= 2,Floors=1,YearFinish=1964,StateId=1,ProjectId=1, Name="Тяговая подстанция №3"},
                    new TransformerSubstation {CoordinatesX = 56.98280590705517 , CoordinatesY = 40.96223160284047, Address="Иваново, Велижская улица, 59А*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-475"},
                    new TransformerSubstation {CoordinatesX = 56.98298456771902, CoordinatesY = 40.96225149999996, Address="Иваново, Велижская улица, 59А*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-475"},
                    new TransformerSubstation {CoordinatesX = 56.98666806769826, CoordinatesY = 40.9771725, Address="Иваново, Улица Володарского, 3*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-249"},
                    new TransformerSubstation {CoordinatesX = 57.00676477876178, CoordinatesY = 40.94313700169494, Address="Иваново, Гаражный переулок, 10*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-53"},
                    new TransformerSubstation {CoordinatesX = 57.013958450779185, CoordinatesY = 40.98423314418026 , Address="Иваново, Улица Генкиной, 60*", BuilderId= 1,Floors=1,YearFinish=1963,StateId=1,ProjectId=5, Name="ТП-413"},
                    new TransformerSubstation {CoordinatesX = 57.01189106770267, CoordinatesY = 40.981673499999935, Address="Иваново, Улица Громобоя, 21*", BuilderId= 1,Floors=1,YearFinish=1967,StateId=1,ProjectId=1, Name="ТП-618"},
                    new TransformerSubstation {CoordinatesX = 57.01157256767163, CoordinatesY = 40.98372149999994, Address="Иваново, Улица Громобоя, 25*", BuilderId= 1,Floors=1,YearFinish=1968,StateId=1,ProjectId=8, Name="ТП-569"},
                    new TransformerSubstation {CoordinatesX = 57.018296067658646, CoordinatesY = 40.961874499999944 , Address="Иваново, Улица Ермака, 15*", BuilderId= 1,Floors=1,YearFinish=1974,StateId=1,ProjectId=9, Name="ТП-705"},
                    new TransformerSubstation {CoordinatesX = 57.00137256770584, CoordinatesY = 40.9675784999999, Address="Иваново, Улица Зверева, 11", BuilderId= 1,Floors=2,YearFinish=1934, StateId=1,ProjectId=1, Name="Тяговая подстанция №1"},
                    new TransformerSubstation {CoordinatesX = 57.00312256771038, CoordinatesY = 40.965880999999946, Address="Иваново, Улица Зверева, 12", BuilderId= 4,Floors=2,YearFinish=1928, YearStart=1926,StateId=1,ProjectId=1, Name="Силовая подстанция №2"},
                    new TransformerSubstation {CoordinatesX =  57.006044067687654, CoordinatesY =40.979696999999916, Address="Иваново, Улица Калинина, 3*", BuilderId= 1,Floors=1,YearFinish=1965,StateId=1,ProjectId=5, Name="ТП-397"},
                    new TransformerSubstation {CoordinatesX = 57.007745067692056, CoordinatesY = 40.979310499999976, Address="Иваново, Улица Калинина, 7*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-97"},
                    new TransformerSubstation {CoordinatesX = 57.007774067692104, CoordinatesY = 40.98037049999992, Address="Иваново, Улица Калинина, 8*", BuilderId= 1,Floors=1,YearFinish=1936,StateId=1,ProjectId=1, Name="ТП-160"},
                    new TransformerSubstation {CoordinatesX = 57.01024906769851, CoordinatesY = 40.97904149999996, Address="Иваново, Улица Калинина, 17*", BuilderId= 1,Floors=1,YearFinish=1935,StateId=1,ProjectId=1, Name="ТП-130"},
                    new TransformerSubstation {CoordinatesX = 57.01605156768314, CoordinatesY = 40.97640000000001, Address="Иваново, Улица Карла Маркса, 32*", BuilderId= 1,Floors=1,YearFinish=1976,StateId=1,ProjectId=7, Name="ТП-742"},
                    new TransformerSubstation {CoordinatesX = 56.98335756772002, CoordinatesY = 40.99622599999998, Address="Иваново, Улица Колесанова, 3*", BuilderId= 1,Floors=1,YearFinish=1967,StateId=1,ProjectId=7, Name="ТП-220"},
                    new TransformerSubstation {CoordinatesX = 56.995175567689955, CoordinatesY = 40.9986785, Address="Иваново, Улица Колотилова, 36*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-31"},
                    new TransformerSubstation {CoordinatesX = 57.00889656766476, CoordinatesY = 40.98516749999996, Address="Иваново, Комсомольская улица, 41*", BuilderId= 1,Floors=1,YearFinish=1983,StateId=1,ProjectId=7, Name="ТП-851"},
                    new TransformerSubstation {CoordinatesX = 57.00235306767817, CoordinatesY = 40.952595, Address="Иваново, Улица Красных Зорь, 12*", BuilderId= 1,Floors=1,YearFinish=1969,StateId=1,ProjectId=9, Name="ТП-615"},
                    new TransformerSubstation {CoordinatesX = 57.002485067678485, CoordinatesY = 40.98479049999997, Address="Иваново, Крутицкая улица, 29*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-124"},
                    new TransformerSubstation {CoordinatesX = 57.00991106769759, CoordinatesY = 40.94311749999989, Address="Иваново, Улица Кузнецова, 112*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-187"},
                    new TransformerSubstation {CoordinatesX = 56.97438106772714, CoordinatesY = 41.00743700000001, Address="Иваново, Улица Куконковых, 82*", BuilderId= 1,Floors=2,StateId=1,ProjectId=1, Name="ТП-478"},
                    new TransformerSubstation {CoordinatesX = 57.00223506767785, CoordinatesY = 40.93654199999996, Address="Иваново, Улица Лебедева-Кумача, 2*", BuilderId= 1,Floors=1,YearFinish=1971,StateId=1,ProjectId=9, Name="ТП-652"},
                    new TransformerSubstation {CoordinatesX = 57.00160756770646, CoordinatesY = 40.932077499999984 , Address="Иваново, Улица Лебедева-Кумача, 3*", BuilderId= 1,Floors=1,StateId=1,ProjectId=5, Name="ТП-357"},
                    new TransformerSubstation {CoordinatesX = 56.96547156773445, CoordinatesY = 40.97089349999993, Address="Иваново, Лежневская улица, 152*", BuilderId= 1,Floors=1,YearFinish=1965,StateId=1,ProjectId=5, Name="ТП-418"},
                    new TransformerSubstation {CoordinatesX = 57.00899456766501, CoordinatesY = 40.97316650000003, Address="Иваново, Проспект Ленина, 64*", BuilderId= 1,Floors=1,YearFinish=1970,StateId=1,ProjectId=6, Name="ТП-78"},
                    new TransformerSubstation {CoordinatesX = 57.001387067675665, CoordinatesY = 40.94829199999994, Address="Иваново, Ленинградская улица, 6*", BuilderId= 1,Floors=1,YearFinish=1963,StateId=1,ProjectId=6, Name="ТП-51"},
                    new TransformerSubstation {CoordinatesX = 56.9929591706653, CoordinatesY = 40.98608693961019, Address="Иваново, Улица Марии Рябининой, 1*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-176"},
                    new TransformerSubstation {CoordinatesX = 56.9987445676991, CoordinatesY = 40.99212050000002, Address="Иваново, Улица Марии Рябининой, 29*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-293"},
                    new TransformerSubstation {CoordinatesX = 56.99979406767159, CoordinatesY = 40.99480649999995, Address="Иваново, Улица Марии Рябининой, 32*", BuilderId= 1,Floors=1,YearFinish=2011,StateId=1,ProjectId=10, Name="ТП-727"},
                    new TransformerSubstation {CoordinatesX = 57.00086756770459, CoordinatesY = 40.96385949999998, Address="Иваново, Улица Мархлевского, 21*", BuilderId= 1,Floors=1,YearFinish=1972,StateId=1,ProjectId=9, Name="ТП-689"},
                    new TransformerSubstation {CoordinatesX = 57.00121727792756, CoordinatesY = 40.96250971363064, Address="Иваново, Улица Мархлевского, 32*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-208"},
                    new TransformerSubstation {CoordinatesX = 56.98947306770552, CoordinatesY = 40.97484599999995, Address="Иваново, Улица Маяковского, 22*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-26"},
                    new TransformerSubstation {CoordinatesX = 56.98990006770658, CoordinatesY = 40.97406449999995, Address="Иваново, Улица Маяковского, 24*", BuilderId= 1,Floors=1,StateId=1,ProjectId=8, Name="ТП-624"},
                    new TransformerSubstation {CoordinatesX = 57.00098056770487, CoordinatesY = 40.95316049999999, Address="Иваново, Улица Менделеева, 16*", BuilderId= 1,Floors=1,YearFinish=1955,StateId=1,ProjectId=11, Name="ТП-303"},
                    new TransformerSubstation {CoordinatesX = 56.98785506770132, CoordinatesY = 40.98036149999994, Address="Иваново, Московская улица, 49*", BuilderId= 1,Floors=1,StateId=1,ProjectId=7, Name="ТП-25"},
                    new TransformerSubstation {CoordinatesX = 56.96724756773902, CoordinatesY = 40.985518000000006, Address="Иваново, Московский микрорайон, 15*", BuilderId= 1,Floors=1,YearFinish=2010,StateId=1,ProjectId=1, Name="ТП-6"},
                    new TransformerSubstation {CoordinatesX = 56.96724756773902, CoordinatesY = 40.985518000000006, Address="Иваново, Улица Наумова, 1*", BuilderId= 1,Floors=1,YearFinish=1975,StateId=1,ProjectId=9, Name="ТП-707"},
                    new TransformerSubstation {CoordinatesX = 57.020716067664914, CoordinatesY = 40.99361199999998, Address="Иваново, Улица Носова, 49А*", BuilderId= 1,Floors=1,StateId=1,ProjectId=4, Name="ТП"},
                    new TransformerSubstation {CoordinatesX = 56.99768556769643, CoordinatesY = 40.94547999999996, Address="Иваново, Улица Парижской Коммуны, 15А*", BuilderId= 1,Floors=1,YearFinish=1973,StateId=1,ProjectId=9, Name="ТП-671"},
                    new TransformerSubstation {CoordinatesX = 56.99912256770007, CoordinatesY = 40.94739349999998, Address="Иваново, Улица Парижской Коммуны, 44*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-171"},
                    new TransformerSubstation {CoordinatesX = 57.00007356770253, CoordinatesY = 40.93554449999993, Address="Иваново, Улица Парижской Коммуны, 60*", BuilderId= 1,Floors=1,StateId=1,ProjectId=7, Name="ТП-271"},
                    new TransformerSubstation {CoordinatesX = 57.00454941395441, CoordinatesY = 40.97732832993254, Address="Иваново, Пограничный переулок, 10А*", BuilderId= 1,Floors=1,StateId=1,ProjectId=6, Name="ТП-507"},
                    new TransformerSubstation {CoordinatesX = 57.03207156766386, CoordinatesY = 40.98002049999999, Address="Иваново, Улица Полка Нормандия-Неман, 71*", BuilderId= 1,Floors=1,YearFinish=1965,StateId=1,ProjectId=1, Name="ТП-531"},
                    new TransformerSubstation {CoordinatesX = 56.98489256772397, CoordinatesY = 40.992677499999985, Address="Иваново, Улица Постышева, 56*", BuilderId= 1,Floors=1,YearFinish=1969,StateId=1,ProjectId=9, Name="ТП-178"},
                    new TransformerSubstation {CoordinatesX = 56.98011056771168, CoordinatesY = 40.964515499999976, Address="Иваново, Улица Поэта Лебедева, 23*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-417"},
                    new TransformerSubstation {CoordinatesX = 56.98381412847225, CoordinatesY = 40.97091622289264, Address="Иваново, Улица Поэта Майорова, 28*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП"},
                    new TransformerSubstation {CoordinatesX = 57.00046056770353, CoordinatesY = 40.990422999999986, Address="Иваново, Улица Поэта Ноздрина, 11*", BuilderId= 1,Floors=1,YearFinish=1979,StateId=1,ProjectId=9, Name="ТП-716"},
                    new TransformerSubstation {CoordinatesX = 57.00015855832371, CoordinatesY = 40.97136788888545, Address="Иваново, Площадь Пушкина, 9*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-182"},
                    new TransformerSubstation {CoordinatesX = 56.99558256769098, CoordinatesY = 40.99172549999996, Address="Иваново, Улица Пушкина, 47*", BuilderId= 1,Floors=1,YearFinish=1975,StateId=1,ProjectId=7, Name="ТП-523"},
                    new TransformerSubstation {CoordinatesX = 57.009912999754775, CoordinatesY = 40.95287994180296, Address="Иваново, Рабфаковская улица, 4*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-14"},
                    new TransformerSubstation {CoordinatesX = 56.99476356768888, CoordinatesY = 40.98049649999991, Address="Иваново, Площадь Революции, 6*", BuilderId= 1,Floors=1,YearFinish=2012,StateId=1,ProjectId=1, Name="ТП-416"},
                    new TransformerSubstation {CoordinatesX = 56.99303370445199, CoordinatesY = 40.98881482209014, Address="Иваново, Рыночный переулок, 2*", BuilderId= 1,Floors=1,YearFinish=1968,StateId=1,ProjectId=8, Name="ТП-105"},
                    new TransformerSubstation {CoordinatesX = 56.99954356770115, CoordinatesY = 40.98754849999998, Address="Иваново, Садовая улица, 12*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-312"},
                    new TransformerSubstation {CoordinatesX = 57.0131845676758, CoordinatesY = 40.99995399999992, Address="Иваново, Улица Сарментовой, 15", BuilderId= 5,Floors=1,YearFinish=1975,StateId=1,ProjectId=12, Name="Тяговая подстанция №10"},
                    new TransformerSubstation {CoordinatesX = 56.96431806776176, CoordinatesY = 40.96735399999999, Address="Иваново, Улица Станкостроителей, 1А", BuilderId= 5,Floors=1,YearFinish=1975,StateId=1,ProjectId=12, Name="Тяговая подстанция №8"},
                    new TransformerSubstation {CoordinatesX = 57.00028906767286, CoordinatesY = 40.955648999999944, Address="Иваново, Строительная улица, 4*", BuilderId= 1,Floors=1,YearFinish=1955,StateId=1,ProjectId=1, Name="ТП-242"},
                    new TransformerSubstation {CoordinatesX = 56.98383356772122, CoordinatesY = 40.97333699999994, Address="Иваново, Улица Танкиста Белороссова, 1*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-885"},
                    new TransformerSubstation {CoordinatesX = 56.99516100180279, CoordinatesY = 40.97582446572188, Address="Иваново, Театральная улица, 2*", BuilderId= 1,Floors=1,StateId=1,ProjectId=7, Name="ТП-13"},
                    new TransformerSubstation {CoordinatesX = 57.03206656766381, CoordinatesY = 40.96793799999996, Address="Иваново, Улица Фрунзе, 17А*", BuilderId= 1,Floors=1,YearFinish=1965,StateId=1,ProjectId=13, Name="ТП-534"},
                    new TransformerSubstation {CoordinatesX = 57.03281656766574, CoordinatesY = 40.9693484999999, Address="Иваново, Улица Фрунзе, 21*", BuilderId= 1,Floors=1,YearFinish=1955,StateId=1,ProjectId=1, Name="ТП-186"},
                    new TransformerSubstation {CoordinatesX = 57.01568406765197, CoordinatesY = 40.98223049999995, Address="Иваново, Улица Фурманова, 27*", BuilderId= 1,Floors=1,YearFinish=1965,StateId=1,ProjectId=5, Name="ТП"},
                    new TransformerSubstation {CoordinatesX = 56.99052206770821, CoordinatesY = 40.927801499999994, Address="Иваново, Шахтинский проезд, 88*", BuilderId= 1,Floors=2,StateId=1,ProjectId=1, Name="ТП-614"},
                    new TransformerSubstation {CoordinatesX = 57.00095106767455, CoordinatesY = 40.987853499999964, Address="Иваново, Шереметевский проспект, 18*", BuilderId= 1,Floors=1,YearFinish=1960,StateId=1,ProjectId=4, Name="ТП-385"},
                    new TransformerSubstation {CoordinatesX = 57.001828567707044, CoordinatesY = 40.989425499999896, Address="Иваново, Шереметевский проспект, 26*", BuilderId= 1,Floors=1,StateId=1,ProjectId=9, Name="ТП-651"},
                    new TransformerSubstation {CoordinatesX = 57.00120556770545, CoordinatesY = 40.985976000000015, Address="Иваново, Шереметевский проспект, 29*", BuilderId= 1,Floors=1,YearFinish=2010,StateId=1,ProjectId=1, Name="Трансформаторная подстанция"},
                    new TransformerSubstation {CoordinatesX = 57.00337756771101, CoordinatesY = 40.987898499999964, Address="Иваново, Шереметевский проспект, 45*", BuilderId= 1,Floors=1,StateId=1,ProjectId=9, Name="ТП-635"},
                    new TransformerSubstation {CoordinatesX = 57.00417156771305, CoordinatesY = 40.989767000000015, Address="Иваново, Шереметевский проспект, 53*", BuilderId= 1,Floors=1,YearFinish=2010,StateId=1,ProjectId=10, Name="ТП-959"},
                    new TransformerSubstation {CoordinatesX = 57.007735067691975, CoordinatesY = 40.98941649999991, Address="Иваново, Шереметевский проспект, 85*", BuilderId= 1,Floors=1,YearFinish=1975,StateId=1,ProjectId=9, Name="ТП-725"},
                    new TransformerSubstation {CoordinatesX = 57.00475506768432, CoordinatesY = 40.94364749999998, Address="Иваново, Ярмарочная улица, 8*", BuilderId= 1,Floors=1,StateId=1,ProjectId=1, Name="ТП-52"},
                    //new TransformerSubstation {CoordinatesX = , CoordinatesY = , Address="", BuilderId= 1,Floors=1,YearFinish=,StateId=1,ProjectId=1, Name=""},
                    //new TransformerSubstation {CoordinatesX = , CoordinatesY = , Address="", BuilderId= 1,Floors=1,YearFinish=,StateId=1,ProjectId=1, Name=""},
                    //new TransformerSubstation {CoordinatesX = , CoordinatesY = , Address="", BuilderId= 1,Floors=1,YearFinish=,StateId=1,ProjectId=1, Name=""},
                    //new TransformerSubstation {CoordinatesX = , CoordinatesY = , Address="", BuilderId= 1,Floors=1,YearFinish=,StateId=1,ProjectId=1, Name=""},
                    //new TransformerSubstation {CoordinatesX = , CoordinatesY = , Address="", BuilderId= 1,Floors=1,YearFinish=,StateId=1,ProjectId=1, Name=""},
                };
                foreach (TransformerSubstation b in TransformerSubstations)
                {
                    context.TransformerSubstation.Add(b);
                }
                context.SaveChanges();
            }

        }


    }
}
