using System;
using System.Collections.Generic;
namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Hello World!");

            //DuplicateZero.TestDuplicateZeros();

            //int[] input = { 4, 3, 2, 7, 8, 2, 3, 1 };
            //ClassPrint.PrintArr(MissingNumber.FindMissingNumber(input));

            //FindMin.Test();

            //ClassPrint.PrintArr(PhoneNumToLetters.ConvertDigitToLetters("").ToArray());
            //ClassPrint.PrintArr(PhoneNumToLetters.ConvertDigitToLetters("23").ToArray());
            //ClassPrint.PrintArr(PhoneNumToLetters.ConvertDigitToLetters("2").ToArray());
            //ClassPrint.PrintArr(PhoneNumToLetters.ConvertDigitToLetters("3769").ToArray());

            //CombinationSums cs = new CombinationSums();
            //int[] candidates = { 2, 3, 6, 7 };
            //ClassPrint.PrintArrays(cs.CombinationSum(candidates, 7));
            //int[] candidates2 = { 2, 3, 5 };
            //ClassPrint.PrintArrays(cs.CombinationSum(candidates2, 8));

            //string[] inputs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            //ClassPrint.PrintArrays<string>(GroupAnagram.GroupAnagrams(new List<string>(inputs)));

            //Console.WriteLine(Power.Pow(15.0, 3));
            //Console.WriteLine(Power.Pow(10, 4));

            //test permutations
            //  some duplicate numbers in array:
            //int[] input1 = { 1, 1, 2 };
            //List<int[]> output1 = Permutations.GetPermutations(input1);
            //ClassPrint.PrintArrays(output1);
            ////unique numbers in the array:
            //int[] input2 = { 1, -1, 2 };
            //List<int[]> output2 = Permutations.GetPermutations(input2);
            //ClassPrint.PrintArrays(output2);
            //int[] input3 = { 1, 1, 1 };
            //List<int[]> output3 = Permutations.GetPermutations(input3);
            //ClassPrint.PrintArrays(output3);
            //int[] input4 = { -1, 1, 2,3,4,5,6,7 };
            //List<int[]> output4 = Permutations.GetPermutations(input4);
            //ClassPrint.PrintArrays(output4);

            //TestBinarySeeach();
            //TestBubbleSort();
            //TestSelectionSort();
            //TestInsertionSort();
            //TestHeapSort();
            //TestMergeSort();

            //TestTreeBinary();

            //WordBreak.Testing();

            //NQueens.Testing();

            //TestMyAtoI();

            //TestMaxSubstring();

            //TestReverseInt();

            //TestMedian2SortedArray();

            //TestIntToRoman();

            //Test3Sums();

            //TestMaxSubArraySum();

            //TestConcateSubstring();

            //FirstMissingInteger();

            //WaterTrap();

            //TestWildMatch();

            //TestKthPermutation();

            //TesNumber();

            //TestTextJustification();

            //TestMinWindowSubStr();

            TestLagestRectArea();
        }

        static void TestBinarySeeach()
        {
            int[] array = { 1, 4, 7, 10, 30, 50 };
            
            Console.WriteLine("Loop: Index of value 10 is: " + SearchBinary.SearchByLoop(array, 10));
            Console.WriteLine("Recursive: Index of value 10 is: " + SearchBinary.SearchByRecursive(array, 0,5, 10));
        }
        static void TestBubbleSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            ClassPrint.PrintArr(SortBubble.Sort(array));
        }

        static void TestSelectionSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            SortSelection.Sort(array);
            ClassPrint.PrintArr(array);
        }


        static void TestInsertionSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            SortInsertion.Sort(array);
            ClassPrint.PrintArr(array);
        }

        static void TestHeapSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            SortHeap heapSort = new SortHeap();
            int[] output = heapSort.Sort(array);
            ClassPrint.PrintArr(output);
        }

        static void TestMergeSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            SortMerge.Sort(array, 0, array.Length - 1);
            ClassPrint.PrintArr(array);
        }

        static void TestQuickSort()
        {
            int[] array = { 1, 50, 30, 10, 4, 7 };
            SortQuick.Sort(array, 0, array.Length - 1);
            ClassPrint.PrintArr(array);
        }

        static void TestTreeBinary()
        {
            //construct the tree:
            Node root = new Node(10);
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Left.Left = new Node(7);
            root.Left.Right = new Node(8);
            root.Right.Right = new Node(15);
            root.Right.Left = new Node(12);
            root.Right.Right.Left = new Node(14);

            TreeBinary TB = new TreeBinary();
            TB.Root = root;
            TB.PreOrder(root);
            TB.InOrder(root);
            TB.PostOrder(root);
            Console.WriteLine("\nRight View:");
            TB.PrintRightView(root);
            Console.WriteLine("\nLeft View:");
            TB.PrintLeftView(root);
            Console.WriteLine("\nLeft View Recursively:");
            int max_level = 0;
            TB.PrintLeftTreeRecursive(root, 1, ref max_level);
        }

        static void TestMyAtoI()
        {
            try
            {
                int number = AtoI.MyAtoI("    4890 aaaa");
                Console.WriteLine("the number is 4890: " + (number == 4890));
                number = AtoI.MyAtoI("    -4890 aaaa");
                Console.WriteLine("the number is 4890: " + (number == -4890));
                number = AtoI.MyAtoI("    a4890 aaaa");
                Console.WriteLine("the number is not a valid number: " + (number == -1));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void TestMaxSubstring()
        {
            Console.WriteLine("The max length non repeat sub string of \"abcddexfghi\" is:" + NonRepeatSubstring.MaxLengthSubString("abcddexfghi"));
            Console.WriteLine("The max length non repeat sub string of \"abcddexfghikk\" is: " + NonRepeatSubstring.MaxLengthSubString("abcddexfghikk"));
        }

        static void TestReverseInt()
        {
            Console.WriteLine("The reverse of 320 is:" + ReverseInt.ReverseInteger(320));
            Console.WriteLine("The reverse of 3020 is:" + ReverseInt.ReverseInteger(3020));
            Console.WriteLine("The reverse of 3205 is:" + ReverseInt.ReverseInteger(3205));
            Console.WriteLine("The reverse of -3205 is:" + ReverseInt.ReverseInteger(-3205));
            Console.WriteLine("The reverse of 2,147,483,648 is:" + ReverseInt.ReverseInteger(2147483647));
        }

        static void TestMedian2SortedArray()
        {
            int[] arr1 = { 1, 5, 9, 10, 11 };
            int[] arr2 = { 2, 4, 8,9, 15 };
            Console.WriteLine("The median is: " + Median2SortedArray.Median2Arrays(arr1, arr2));
        }

        static void TestIntToRoman()
        {
            Console.WriteLine("The roman for 45 is: " + IntToRoman.IntergerToRoman(45));
            Console.WriteLine("The roman for 5 is: " + IntToRoman.IntergerToRoman(5));
            Console.WriteLine("The roman for 4 is: " + IntToRoman.IntergerToRoman(4));
            Console.WriteLine("The roman for 3 is: " + IntToRoman.IntergerToRoman(3));
            Console.WriteLine("The roman for 8 is: " + IntToRoman.IntergerToRoman(8));
            Console.WriteLine("The roman for 58 is: " + IntToRoman.IntergerToRoman(58));
            Console.WriteLine("The roman for 1994 is: " + IntToRoman.IntergerToRoman(1994));
        }

        static void Test3Sums()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            ClassPrint.PrintArrays(ThreeSum.GetAllListWith3SumsTo0(nums));
            int[] nums_1 = { 0, 1, 1 };
            ClassPrint.PrintArrays(ThreeSum.GetAllListWith3SumsTo0(nums_1));
            int[] nums_2 = { 0, 0, 0 };
            ClassPrint.PrintArrays(ThreeSum.GetAllListWith3SumsTo0(nums_2));
        }

        static void TestMaxSubArraySum()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine("Maximun continuous sub array Sum is: " + MaximumSubArray.MaxSumSubArray(nums));
            Console.WriteLine("Maximum cont sub array sum (D n C) is: " + MaximumSubArray.MaxSumSubArrayDivideAndConque(nums, 0, nums.Length - 1));
            int[] nums1 = { 1 };
            Console.WriteLine("Maximun continuous sub array Sum is: " + MaximumSubArray.MaxSumSubArray(nums1));
            Console.WriteLine("Maximum cont sub array sum (D n C) is: " + MaximumSubArray.MaxSumSubArrayDivideAndConque(nums1, 0, nums1.Length - 1));
            int[] nums2 = { 1, 2, 3 };
            Console.WriteLine("Maximun continuous sub array Sum is: " + MaximumSubArray.MaxSumSubArray(nums2));
            Console.WriteLine("Maximum cont sub array sum (D n C) is: " + MaximumSubArray.MaxSumSubArrayDivideAndConque(nums2, 0, nums2.Length - 1));
            int[] nums3 = {3,2, 1 };
            Console.WriteLine("Maximun continuous sub array Sum is: " + MaximumSubArray.MaxSumSubArray(nums3));
            Console.WriteLine("Maximum cont sub array sum (D n C) is: " + MaximumSubArray.MaxSumSubArrayDivideAndConque(nums3, 0, nums3.Length - 1));
        }

        static void TestConcateSubstring()
        {
            string s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };
            ClassPrint.PrintArr(SubstringWithConcateWords.FindSubstring(s, words).ToArray());

            string s1 = "wordgoodgoodgoodbestword";
            string[] words1 = { "word", "good", "best", "word" };
            ClassPrint.PrintArr(SubstringWithConcateWords.FindSubstring(s1, words1).ToArray());

            string s2 = "barfoofoobarthefoobarman";
            string[] words2 = { "bar", "foo", "the" };
            ClassPrint.PrintArr(SubstringWithConcateWords.FindSubstring(s2, words2).ToArray());
        }

        static void FirstMissingInteger()
        {
            int[] nums = { 1, 2, 3, 4, 5 }; 
            Console.WriteLine("Missing positive integer is: " + MissingPosInteger.FirstMissingPositive(nums));

            int[] nums1 = { 1,2,0 };
            Console.WriteLine("Missing positive integer is: " + MissingPosInteger.FirstMissingPositive(nums1));

            int[] nums2 = { 3, 4, -1, 1 };
            Console.WriteLine("Missing positive integer is: " + MissingPosInteger.FirstMissingPositive(nums2));


            int[] nums3 = { 3, 3, 3 };
            Console.WriteLine("Missing positive integer is: " + MissingPosInteger.FirstMissingPositive(nums3));

            int[] nums4 = { 7, 8, 9, 11, 12 };
            Console.WriteLine("Missing positive integer is: " + MissingPosInteger.FirstMissingPositive(nums4));
        }

        static void WaterTrap()
        {
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine("Water trapped: " + WaterTrapping.Trap(height));
            int[] height2 = { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine("Water trapped: " + WaterTrapping.Trap(height2));
        }

        static void TestWildMatch()
        {
            string input = "baaabab";
            string pattern = "*****ba*****ab";
            Console.WriteLine("Is a match: " + WildCardMatch.IsMatch(input, pattern));
        }

        static void TestKthPermutation()
        {
            Console.WriteLine("n=3, k=3 permutation is: " + KthPermutationOfN.FindKthPermutation(3, 3));
            Console.WriteLine("n=3, k=4 permutation is: " + KthPermutationOfN.FindKthPermutation(3, 4));
            Console.WriteLine("n=4, k=9 permutation is: " + KthPermutationOfN.FindKthPermutation(4, 9));
        }

        static void TesNumber()
        {
            Console.WriteLine("453 is " + (ValidNum.IsvalidNum("453") ? "a valid number,":"not a valid number."));
            Console.WriteLine("453.. is " + (ValidNum.IsvalidNum("453") ? "a valid number," : "not a valid number."));
            Console.WriteLine("00453 is " + (ValidNum.IsvalidNum("00453") ? "a valid number," : "not a valid number."));
            Console.WriteLine("453. is " + (ValidNum.IsvalidNum("453.") ? "a valid number," : "not a valid number."));
            Console.WriteLine("+453 is " + (ValidNum.IsvalidNum("+453") ? "a valid number," : "not a valid number."));
            Console.WriteLine("+-453.. is " + (ValidNum.IsvalidNum("+-453") ? "a valid number," : "not a valid number."));
            Console.WriteLine("-.9 is " + (ValidNum.IsvalidNum("-.9") ? "a valid number," : "not a valid number."));
            Console.WriteLine("3e+7 is " + (ValidNum.IsvalidNum("3e+7") ? "a valid number," : "not a valid number."));
            Console.WriteLine("3e+-7 is " + (ValidNum.IsvalidNum("3e+-7") ? "a valid number," : "not a valid number."));
        }

        static void TestTextJustification()
        {
            string[] words = { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"};
            List<string> lines = TextJustification.FullJustify(words, 20);
            for(int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }

        static void TestMinWindowSubStr()
        {
            string s = "ADOBECODEBANC", t = "ABC";
            Console.WriteLine("The min sub string is: " + MinWinSubstring.MinWindow(s, t));

            string s1 = "obzcopzocynyrsgsarijyxnkpnukkrvzuwdjldxndmnvevpgmxrmvfwkutwekrffnloyqnntbdohyfqndhzyoykiripdzwiojyoznbtogjyfpouuxvumtewmmnqnkadvzrvouqfbbdiqremqzgevkbhyoznacqwbhtrcjwfkzpdstpjswnpiqxjhywjanhdwavajrhwtwzlrqwmombxcaijzevbtcfsdcuovckoalcseaesmhrrizcjgxkbartdtotpsefsrjmvksqyahpijsrppdqpvmuocofuunonybjivbjviyftsyiicbzxnwnrmvlgkzticetyfcvqcbjvbufdxgcmesdqnowzpshuwcseenwjqhgsdlxatamysrohfnixfprdsljyyfhrnnjsagtuihuczilgvtfcjwgdhpbixlzmakebszxbhrdibpoxiwztshwczamwnninzmqrmpsviydkptjzpktksrortapgpxwojofxeasoyvyprjoguhqobehugwdvtzlenrcttuitsiijswpogicjolfxhiscjggzzissfcnxnvgftxvbfzkukqrtalvktdjsodmtgzqtuyaqvvrbuexgwqzwduixzrpnvegddyyywaquxjxrnuzlmyipuqotkghfkpknqinoidifnfyczzonxydtqroazxhjnrxfbmtlqcsfhshjrxwqvblovaouxwempdrrplefnxmwrwfjtebrfnfanvvmtbzjesctdgbsfnpxlwihalyiafincfcwgdfkvhebphtxukwgjgplrntsuchyjjuqozakiglangxkttsczhnswjksnuqwflmumpexxrznzwxurrysaokwxxqkrggytvsgkyfjrewrcvntomnoazmzycjrjrqemimyhriyxgrzcfuqtjhvjtuhwfzhwpljzajitrhryaqchnuawbxhxrpvyqcvhpggrpplhychyulijhkglinibedauhvdydkqszdbzfkzbvhldstocgydnbfjkcnkfxcyyfbzmmyojgzmasccaahpdnzproaxnexnkamwmkmwslksfpwirexxtymkmojztgmfhydvlqtddewjvsrmyqjrpycbmndhupmdqqabiuelacuvxnhxgtpvrtwfgzpcrbhhtikbcqpctlxszgpfbgcsbaaiapmtsucocmpecgixshrrnhyrpalralbccnxvjzjllarqhznzghswqsnfuyywmzbopyjyauknxddgdthlabjqtwxpxwljvoxkpjjpfvccyikbbrpdsyvlxscuoofkecwtnfkvcnzbxkeabtdusyhrqklhaqreupakxkfzxgawqfwsaboszvlshwzhosojjotgyagygguzntrouhiweuomqptfjjqsxlbylhwtpssdlltgubczxslqjgxuqnmpynnlwjgmebrpokxjnbiltvbebyytnnjlcwyzignmhedwqbfdepqakrelrdfesqrumptwwgifmmbepiktxavhuavlfaqxqhreznbvvlakzeoomykkzftthoemqwliednfsqcnbexbimrvkdhllcesrlhhjsspvfupxwdybablotibypmjutclgjurbmhztboqatrdwsomnxnmocvixxvfiqwmednahdqhxjkvcyhpxxdmzzuyyqdjibvmfkmonfxmohhshpkhmntnoplphqyprveyfsmsxjfosmicdsjrieeytpnbhlsziwxnpmgoxneqbnufhfwrjbqcsdfarybzwaplmxckkgclvwqdbpumsmqkswmjwnkuqbicykoisqwoootrdpdvcuiuswfqmrkctsgrevcxnyncmivsxbpbxzxpwchiwtkroqisnmrbmefbmatmdknaklpgpyqlsccgunaibsloyqpnsibwuowebomrmcegejozypjzjunjmeygozcjqbnrpakdermjcckartbcppmbtkhkmmtcngteigjnxxyzaibtdcwutkvpwezisskfaeljmxyjwykwglqlnofhycwuivdbnpintuyhtyqpwaoelgpbuwiuyeqhbvkqlsfgmeoheexbhnhutxvnvfjwlzfmvpcghiowocdsjcvqrdmkcizxnivbianfpsnzabxqecinhgfyjrjlbikrrgsbgfgyxtzzwwpayapfgueroncpxogouyrdgzdfucfrywtywjeefkvtzxlwmrniselyeodysirqflpduvibfdvedgcrzpzrunpadvawfsmmddqzaaahfxlifobffbyzqqbtlcpquedzjvykvarayfldvmkapjcfzfbmhscdwhciecsbdledspgpdtsteuafzbrjuvmsfrajtulwirzagiqjdiehefmfifocadxfuxrpsemavncdxuoaetjkavqicgndjkkfhbvbhjdcygfwcwyhpirrfjziqonbyxhibelinpllxsjzoiifscwzlyjdmwhnuovvugfhvquuleuzmehggdfubpzolgbhwyeqekzccuypaspozwuhbzbdqdtejuniuuyagackubauvriwneeqfhtwkocuipcelcfrcjcymcuktegiikyosumeioatfcxrheklookaqekljtvtdwhxsteajevpjviqzudnjnqbucnfvkybggaybebljwcstmktgnipdyrxbgewqczzkaxmeazpzbjsntltjwlmuclxirwytvxgvxscztryubtjweehapvxrguzzsatozzjytnamfyiitreyxmanhzeqwgpoikcjlokebksgkaqetverjegqgkicsyqcktmwjwakivtsxjwrgakphqincqrxqhzbcnxljzwturmsaklhnvyungjrxaonjqomdnxpnvihmwzphkyuhwqwdboabepmwgyatyrgtboiypxfavbjtrgwswyvcqhzwibpisydtmltbkydhznbsvxktyfxopwkxzbftzknnwipghuoijrbgqnzovxckvojvsqqraffwowfvqvfcmiicwitrhxdeombgesxexedlakitfovtydxunqnwqqdeeekiwjnwoshqcsljiicgobbbuqakjdonjawgjlezdnqhfdqnmsuavxdpnfzwipmspiabveaarshzwxmirgkmfncvtdrdvfxkpxlkdokxgtwcskmjryyymcthfnkasinihaunohkxaibtsqelockaefjmsuolebtnepauwmrxutspjwaxbmahsjtkfkxlnszribmeofbkyvbjscjtqjakuwvcgunvnonvqbbggfshauqsyznokqbhowjusypfnecffenojfvlblgzntqzlrgzprvhqnpfrrkzxznieiuivajivzijsqijigtatifmbplzqahuidegfoobpymkputzamzvweiyvvzlwihgmmmrcburbgbsdxrfjsbiylitghgcpqjbevvgypxcybubyoijijrhuzcdijfybqbfowlookqmlnplbxvjjosfqviygqyhgamuwzjklbyzopkrnhbywtfoqomweldmlrhjqswctubiknzzvcztyehouvnyiqnvkufaobehxhrjvtisxjlxoumipzjarwvbsaegdkpbsjmpevjbewzuqnfhoohhmdjgfpmjzdmtmykqvtucptwfidpwtwffzolffzqfdearclkyeecuzabjeqhxpmfodsvisnpxrqowdawheydfyhoexvcmihdlzavtqlshdhdgjzpozvvackebhgqppvcrvymljfvooauxcjnbejdivikcoaugxwzsulgfqdtefpehbrlhaoqxwcancuvbqutnfbuygoemditeagmcveatgaikwflozgdhkyfqmjcruyyuemwbqwxyyfiwnvlmbovlmccaoguieu";
            string t1 = "cjgamyzjwxrgwedhsexosmswogckohesskteksqgrjonnrwhywxqkqmywqjlxnfrayykqotkzhxmbwvzstrcjfchvluvbaobymlrcgbbqaprwlsqglsrqvynitklvzmvlamqipryqjpmwhdcsxtkutyfoiqljfhxftnnjgmbpdplnuphuksoestuckgopnlwiyltezuwdmhsgzzajtrpnkkswsglhrjprxlvwftbtdtacvclotdcepuahcootzfkwqhtydwrgqrilwvbpadvpzwybmowluikmsfkvbebrxletigjjlealczoqnnejvowptikumnokysfjyoskvsxztnqhcwsamopfzablnrxokdxktrwqjvqfjimneenqvdxufahsshiemfofwlyiionrybfchuucxtyctixlpfrbngiltgtbwivujcyrwutwnuajcxwtfowuuefpnzqljnitpgkobfkqzkzdkwwpksjgzqvoplbzzjuqqgetlojnblslhpatjlzkbuathcuilqzdwfyhwkwxvpicgkxrxweaqevziriwhjzdqanmkljfatjifgaccefukavvsfrbqshhswtchfjkausgaukeapanswimbznstubmswqadckewemzbwdbogogcysfxhzreafwxxwczigwpuvqtathgkpkijqiqrzwugtr";

            Console.WriteLine("The min sub string is: " + MinWinSubstring.MinWindow(s1, t1));
        }

        static void TestLagestRectArea()
        {
            int[] hist = { 2, 1, 5, 6, 2, 3 };
            Console.WriteLine("The Lagest Rect Area is: " + LargestRect.MaxArea(hist));
            int num = 123_30;
            Console.WriteLine("num == " + num);
        }
    }
}
