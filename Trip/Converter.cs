namespace Trip
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class Converter
    {
        /// <summary>
        /// На вход получаем "Карточки".
        /// При первом проходе по ним формируем словарь связей. Ключ - город отправления. Значение- город прибытия.
        /// Если города прибытия в качестве ключа еще не было в словаре, 
        /// то добавляем его, и гзначением для него ставим string.empty.
        /// Потом меняем ключи и значения местами, для более удобного поиска.
        /// Зная, что у последнего города в значении( а сейчас в ключе) стоит string.empty, то можем его легко найти.
        /// Далее по цепочке восстанавливаем весь путь от конца к началу.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string[] TourListToChain(List<Tour> list)
        {
            var chains = new Dictionary<string, string>();
            var lastCity = string.Empty;////ключ для последнего города string.empty
            ////Формирование словаря связей
            foreach (var tour in list) 
            {
                chains[tour.From] = tour.To;
                if (!chains.ContainsKey(tour.To)) chains[tour.To] = lastCity; 
            }
            ////"Разворот словаря"
            var reversedChains = chains.ToDictionary(x => x.Value, x => x.Key);

            string[] tripChain = new string[reversedChains.Count];

            for (var i = reversedChains.Count-1; i >= 0; i--)////По цепочке от последнего города к первому восстанавливаем весь путь.
            {
                lastCity = reversedChains[lastCity];
                tripChain[i] = lastCity;
            }
            return tripChain;
        }
    }
}
