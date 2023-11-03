using System;
using System.Collections.Generic;
using System.Linq;


namespace Model.Common
{

  public static class LINQExtensions
  {
    private static readonly Random random = new Random();

    public static T randomElement<T>( this Array array )
    {
      if ( array.Length == 0 )
        return default( T );

      int index = random.Next( 0, array.Length );
      return (T)array.GetValue( index );
    }

    public static T randomElement<T>( this IReadOnlyList<T> list ) => list.randomElement<T>( random );

    public static T randomElement<T>( this IReadOnlyList<T> list, Random rnd )
    {
      if ( list.Count == 0 )
        return default( T );

      int index = rnd.Next( 0, list.Count );
      return list[index];
    }

    public static T randomElement<T>( this T[] list ) => list.randomElement<T>( random );

    public static T randomElement<T>( this T[] list, Random rnd )
    {
      if ( list.Length == 0 )
        return default( T );

      int index = rnd.Next( 0, list.Length );
      return list[index];
    }

    public static T randomElement<T>( this IReadOnlyCollection<T> enumerable ) => enumerable.randomElement<T>( new Random() );

    private static T randomElement<T>( this IReadOnlyCollection<T> enumerable, Random rand )
    {
      int index = rand.Next( 0, enumerable.Count );
      return enumerable.ElementAt<T>( index );
    }

    public static TValue randomElement<TKey, TValue>( this Dictionary<TKey, TValue> dictionary ) => dictionary.randomElement<TKey, TValue>( random );

    public static TValue randomElement<TKey, TValue>( this Dictionary<TKey, TValue> dictionary, Random rnd )
    {
      if ( dictionary.Count == 0 )
        return default( TValue );

      int index = rnd.Next( 0, dictionary.Count );
      return dictionary.Values.ElementAt<TValue>( index );
    }

    public static void setOrIncrement<TKey>( this IDictionary<TKey, int> dict, TKey key, int value = 1 )
    {
      int num;
      dict.TryGetValue( key, out num );
      dict[key] = num + value;
    }

    public static T safeGet<T>( this List<T> arr, int idx, bool last_if_count_exceeded = true )
    {
      if ( idx < 0 )
        return default( T );

      if ( arr == null || arr.Count == 0 )
        return default( T );

      return idx >= arr.Count ? ( last_if_count_exceeded ? arr[^1] : default( T ) ) : arr[idx];
    }

    public static T safeGet<T>( this T[] arr, int idx, bool last_if_count_exceeded = true )
    {
      if ( idx < 0 )
        return default( T );

      if ( arr == null || arr.Length == 0 )
        return default( T );

      return idx >= arr.Length ? ( last_if_count_exceeded ? arr[^1] : default( T ) ) : arr[idx];
    }

    public static TValue safeGet<TKey, TValue>( this IReadOnlyDictionary<TKey, TValue> dict, TKey key )
    {
      TValue obj;
      return dict != null && (object)key != null && dict.TryGetValue( key, out obj ) ? obj : default( TValue );
    }

    public static T safeGet<T>( this IReadOnlyList<T> arr, int idx, bool last_if_count_exceeded = true )
    {
      if ( idx < 0 )
        return default( T );

      if ( arr == null || arr.Count == 0 )
        return default( T );

      return idx >= arr.Count ? ( last_if_count_exceeded ? arr[^1] : default( T ) ) : arr[idx];
    }
  }

}