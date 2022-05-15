using System.Collections;

namespace EnumerableCollection;

public class MyClass : IEnumerable<object>
{
	private readonly List<object> _objects;

	public MyClass()
	{
		_objects = new List<object>();
	}

	public MyClass(int count)
	{
		_objects = new List<object>(count);
	}
	public IEnumerator<object> GetEnumerator()
	{
		return new MyEnumerator(_objects.ToArray());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(object o) => _objects.Add(o);
	public void Remove(object o) => _objects.Remove(o);
	public void Clear() => _objects.Clear();

	class MyEnumerator : IEnumerator<object>
	{
		private object[] _array;
		private int index;

		public MyEnumerator(object[] array)
		{
			_array = array;
			index = _array.Length;
		}

		public bool MoveNext()
		{
			if (index > 0)
			{
				index--;
				return true;
			}
			else return false;
		}

		public void Reset()
		{
			index = _array.Length;
		}

		public object Current => _array[index];

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			_array = null;
		}
	}
}