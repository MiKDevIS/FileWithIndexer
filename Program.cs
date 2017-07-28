using System;
using System.IO;
using System.Xml.Serialization;

namespace IndexListVer1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            MainManager mainManager = new MainManager();
            mainManager.Main();
        }

    }

    class MainManager
    {
        public void Main()
        {
            bool condition;
            Console.WriteLine("-*-*- Welcome to virtualization of List with Index -*-*-");
            StudentList slNew;
            StudentList slLoaded = new StudentList(true);
            StudentList worker;
            do
            {
                Console.WriteLine("\nChoose option to continue ==>");
                Console.WriteLine("1) work on loaded list.\n2) work on new list.");
                Console.Write("Option ==> ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            worker = slLoaded;
                            worker.List = SaveAndLoad.DeSerializationCamera();
                            worker.CreateIndexFromList();
                            bool conditionC1;
                            do
                            {
                                Console.WriteLine("\nChoose option to continue ==>");
                                Console.WriteLine("1) Print Indexer.\n2) Print List.\n3) Find Item.");
                                Console.Write("Option ==> ");
                                switch (int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                        {
                                            worker.printIndexer();
                                        }
                                        break;

                                    case 2:
                                        {
                                            worker.printList();
                                        }
                                        break;

                                    case 3:
                                        {
                                            worker.findItem();
                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("you choose wrong number!");
                                        }
                                        break;
                                }
                                Console.Write("\nyou are in loaded list");
                                Console.Write("\nFor continue at this list press y : ");
                                if (Console.ReadKey().KeyChar == 'y')
                                {
                                    conditionC1 = true;
                                }
                                else
                                {
                                    conditionC1 = false;
                                }

} while (conditionC1);
                        }
                        break;
                    case 2:
                        {
                            slNew = new StudentList();
                            worker = slNew;
                            bool conditionC2;
                            do
                            {
                                Console.WriteLine("\nChoose option to continue ==>");
                                Console.WriteLine("1) Print Indexer.\n2) Print List.\n3) Find Item.\n4) Save List.");
                                Console.Write("Option ==> ");
                                switch (int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                        {
                                            worker.printIndexer();
                                        }
                                        break;

                                    case 2:
                                        {
                                            worker.printList();
                                        }
                                        break;

                                    case 3:
                                        {
                                            worker.findItem();
                                        }
                                        break;

                                    case 4:
                                        {
                                            SaveAndLoad.SerializationObjects(worker.List);
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("you choose wrong number!");
                                        }
                                        break;
                                }
                                Console.Write("\nyou are in new list");
                                Console.Write("\nFor continue at this list press y : ");
                                if (Console.ReadKey().KeyChar == 'y')
                                {
                                    conditionC2 = true;
                                }
                                else
                                {
                                    conditionC2 = false;
                                }
                            } while (conditionC2);

                        }
                        break;
                    default:
                        {
                            Console.WriteLine("you choose wrong number!");
                        }
                        break;
                }
                Console.Write("\nyou are in main");
                Console.Write("\nFor continue at this list press y : ");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    condition = true;
                }
                else
                {
                    condition = false;
                }

} while (condition);
            Console.WriteLine("\nThank You!!!");
            Console.ReadKey();
        }
    }
    class Sort
    {
        public static Indexer[] InsertionSort(Indexer[] index)
        {
            int i;
            Indexer IN;
            for (int k = 2; k < index.Length; k++)
            {
                IN = index[k];
                i = k - 1;
                while (InternalIndex.Equal(index[i].Index, IN.Index) && i > 0)
                {
                    index[i + 1] = index[i];
                    i--;
                }
                index[i + 1] = IN;
            }
            if (InternalIndex.Equal(index[0].Index, index[1].Index))
            {
                IN = index[0];
                index[0] = index[1];
                index[1] = IN;
            }
            return index;
        }
    }
    public class StudentList
    {
        string[] _title = new string[] { "Name", "Surename", "Birthday", "StudentID", "Avg.", "PresonalID" };
        InternalStudentList[] _list;
        Indexer[] _indexer;

        public InternalStudentList[] List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
            }
        }

        public Indexer[] Indexer
        {
            get
            {
                return _indexer;
            }

            set
            {
                _indexer = value;
            }
        }

        public StudentList()
        {
            Console.Write("Please Enter number of Students?\t");
            listBuilder(int.Parse(Console.ReadLine()));

        }
        public StudentList(bool condition)
        {

        }
        public StudentList(int n)
        {
            listBuilder(n);
        }
        private void listBuilder(int n)
        {
            _list = new InternalStudentList[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("------ Student {0} —---", i + 1);
                _list[i] = new InternalStudentList(true);
            }
            Console.WriteLine("------ End —---");
            _indexer = new Indexer[n];
            indexerBuilder();
        }
        public void CreateIndexFromList()
        {
            indexerBuilder(List.Length);
        }
        private void indexerBuilder(int length)
        {
            _indexer = new Indexer[length];
            for (int i = 0; i < _indexer.Length; i++)
            {
                _indexer[i] = new Indexer();
                _indexer[i].Index.Index = _list[i].Student[3];
                _indexer[i].Index.IndexRefrence = _list[i];
            }
            insertionSort();
        }
        private void indexerBuilder()
        {
            for (int i = 0; i < _indexer.Length; i++)
            {
                _indexer[i] = new Indexer();
                _indexer[i].Index.Index = _list[i].Student[3];
                _indexer[i].Index.IndexRefrence = _list[i];
            }
            insertionSort();
        }

private void insertionSort()
        {
            _indexer = Sort.InsertionSort(_indexer);
        }
        public void printIndexer()
        {
            Console.WriteLine("---— print indexer —---");
            Console.WriteLine("-*-*- Sorted Student ID reference -*-*-");
            for (int i = 0; i < _indexer.Length; i++)
            {
                Console.WriteLine(_indexer[i].Index.Index);
                Console.WriteLine("-*-*-*-*-*-");
            }
        }
        public void printList()
        {
            Console.WriteLine("---— print full list —---");
            Console.WriteLine("-*-*- Full List Of Students -*-*-");
            Console.WriteLine("\t{0}\t|\t{1}\t|\t{2}\t|\t{3}\t|\t{4}\t|\t{5}\t", _title[0], _title[1], _title[2], _title[3], _title[4], _title[5]);
            for (int i = 0; i < _list.Length; i++)
            {
                Console.WriteLine("\t{0}\t|\t{1}\t|\t{2}\t|\t{3}\t|\t{4}\t|\t{5}\t", _list[i].Student[0], _list[i].Student[1], _list[i].Student[2], _list[i].Student[3], _list[i].Student[4], _list[i].Student[5]);
            }
            Console.WriteLine("-*-*-*-*-*-");
        }
        public void findItem()
        {

        }
    }
    public class InternalStudentList
    {
        string[] _student;

        public string[] Student
        {
            get
            {
                return _student;
            }

            set
            {
                _student = value;
            }
        }
        public InternalStudentList(bool condition)
        {
            _student = new string[6];
            fillData();
        }
        public InternalStudentList()
        {

        }
        private void fillData()
        {
            fillName();
            fillSurename();
            fillBirthday();
            fillStudentID();
            fillAvg();
            fillPersonalID();
        }
        private void fillName()
        {
            Console.Write("Please Enter Student Name?\t");
            _student[0] = Console.ReadLine();
        }
        private void fillSurename()
        {
            Console.Write("Please Enter Student Surename?\t");
            _student[1] = Console.ReadLine();
        }
        private void fillBirthday()
        {
            Console.Write("Please Enter Student Birthday?\t");
            _student[2] = Console.ReadLine();
        }
        private void fillStudentID()
        {
            Console.Write("Please Enter Student ID?\t");
            _student[3] = Console.ReadLine();
        }
        private void fillAvg()
        {
            Console.Write("Please Enter Student Avrage?\t");
            _student[4] = Console.ReadLine();
        }
        private void fillPersonalID()
        {
            Console.Write("Please Enter Student Personal ID?\t");
            _student[5] = Console.ReadLine();
        }
    }
    public class Indexer
    {
        InternalIndex _index;

        public Indexer()
        {
            _index = new InternalIndex();
        }

        public InternalIndex Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }
    }
    public class InternalIndex
    {
        string _index;
        InternalStudentList _indexReference;

        public string Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        public InternalStudentList IndexRefrence
        {
            get
            {
                return _indexReference;
            }

            set
            {
                _indexReference = value;
            }
        }

public static bool Equal(InternalIndex objA, InternalIndex objB)
        {
            if (string.Compare(objA._index, objB._index) < 0)
            {
                return true;
            }
            return false;
        }
    }
    class SaveAndLoad
    {
        public static void SerializationObjects(InternalStudentList[] sl)
        {
            // Create and instance of XmlSerializer class.
            var xmlSerializer = new XmlSerializer(typeof(InternalStudentList[]));
            // Create an instance of stream writer.
            TextWriter txtWriter = new StreamWriter(@"C:\Users\Milad\Documents\Visual Studio 2015\Projects\IndexListVer1.0\IndexListVer1.0\fileList.xml");
            // Serialize the instance of BasicSerialization
            xmlSerializer.Serialize(txtWriter, sl);
            // Close the stream writer
            txtWriter.Close();
        }
        public static InternalStudentList[] DeSerializationCamera()
        {
            // Create an instance of InternalStudentList class.
            InternalStudentList[] sl;
            // Create an instance of stream writer.
            TextReader txtReader = new StreamReader(@"C:\Users\Milad\Documents\Visual Studio 2015\Projects\IndexListVer1.0\IndexListVer1.0\fileList.xml");
            // Create and instance of XmlSerializer class.
            var xmlSerializer = new XmlSerializer(typeof(InternalStudentList[]));
            // DeSerialize from the StreamReader
            sl = (InternalStudentList[])xmlSerializer.Deserialize(txtReader);
            // Close the stream reader
            txtReader.Close();
            return sl;
        }
    }

}