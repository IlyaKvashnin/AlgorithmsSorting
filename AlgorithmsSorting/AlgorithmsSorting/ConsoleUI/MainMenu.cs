
namespace AlgorithmsSorting.ConsoleUI
{
    public class MainMenu
    {
        public static MenuCategory mainMenu = new MenuCategory("Главное меню", new Menu[]
            {

                 new MenuCategory("Cортировка текста",new Menu[]
                {
                    new MenuApplicationTextSorting("Сортировка выборками",TextSortingActions.PrintSelectionSort),
                    new MenuApplicationTextSorting("Поразрядная сортировка",TextSortingActions.PrintRadixSort),
                    new ReturnMenu("Вернуться назад")
                }),
                new MenuCategory("Алгоритмы внутренней сортировки",new Menu[]
                {
                    new ReturnMenu("Вернуться назад")
                }),
                new MenuCategory("Алгоритмы внешней сортировки",new Menu[]
                {
                    new MenuApplicationExternalSorting("Сортировка прямым слиянием",ExternalSortingActions.PrintDirectMergeSort),
                    new MenuApplicationExternalSorting("Сортировка естественным слиянием",ExternalSortingActions.PrintNaturalMergeSort),
                    new MenuApplicationExternalSorting("Сортировка многопутевым слиянием",ExternalSortingActions.PrintMultipathMergeSort),
                    new ReturnMenu("Вернуться назад")
                }),
                new ReturnMenu("Выход")
            });
    }
}
