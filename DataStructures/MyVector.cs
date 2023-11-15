using System.Net.Sockets;
using System.Text;

namespace DataStructures;

public class MyVector<T> where T : IEquatable<T>
{
    private T[] data;
    private int size;

    public int Size
    {
        get { return this.size;  }
    }

    public MyVector()
    {
        this.data = new T[2];
        this.size = 0;
    }
    public MyVector(T[] other, int size)
    {
        this.data = new T[other.Length];
        Array.Copy(other, this.data, other.Length);
        this.size = size;
    }

    public MyVector(int capacity)
    {
        this.data = new T[capacity];
        this.size = 0;
    }
    public MyVector(MyVector<T> other)
    {
        this.data = new T[other.data.Length];
        Array.Copy(other.data, this.data, other.data.Length);
        this.size = other.size;
    }

    public void Add(T item)
    {
        if(this.size == this.data.Length) {
            var NewData = new T[this.data.Length * 2];
            Array.Copy(this.data, NewData, this.data.Length);
            this.data = NewData;
        }

        this.data[this.size] = item;
        this.size++;
    }

    public T this[int index]
    {
        get
        {
            if(index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException(index + " is out of bounds for " + this.size);
            }

            return this.data[index];
        }
        set
        {
            if(index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException(index + " is out of bounds for " + this.size);
            }

            this.data[index] = value;
        }
    }
    public T Remove(int index) {
        if(index < 0 || index >= this.size) {
            throw new IndexOutOfRangeException(index + " is out of bounds for " + this.size);
        }
        if(index == (this.size - 1)) {
            return this.data[this.size--];
        }
        var RetItem = this.data[index];
        Array.Copy(data, index + 1, data, index, this.size - 1 );
        this.size--;
        return RetItem;
    }
    public int Find(T item)
    {
        for (var i = 0; i < this.size; i++)
        {
            if (this.data[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return Find(item) != -1;
    }

    public bool IsEmpty()
    {
        return this.size == 0;
    }
    


    public override string ToString()
    {
        if (this.IsEmpty())
        {
            return "[]";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (var i = 0; i < this.size - 1; i++)
        {
            sb.Append(this.data[i] + ", ");
        }

        sb.Append(this.data[this.size - 1] + "]");
        return sb.ToString();
    }
}