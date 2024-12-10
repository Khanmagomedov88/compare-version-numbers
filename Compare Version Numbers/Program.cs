using System;


/// <summary>
/// # 165
/// 
/// Даны две строки версий, version1 и version2, сравните их. Строка версии состоит из ревизий, 
/// разделённых точками '.'.Значение ревизии — это её целочисленное преобразование без учёта 
/// ведущих нулей.
/// 
/// Чтобы сравнить строки версий, сравните их значения версий в порядке слева направо. 
/// Если в одной из строк версий меньше значений версий, считайте отсутствующие значения версий как 0.
/// 
/// Если version1 < version2, верните значение -1.
/// Если version1 > version2, верните значение 1.
///  В противном случае верните 0
/// </summary>
internal class Program 
{
	private static void Main(string[] args)
	{
        Console.Write("Введите первую версию: ");
		var ver1 = Console.ReadLine();
        Console.Write("Введите вторую версию: ");
		var ver2 = Console.ReadLine();
		var ov = CompareVersion(ver1, ver2);

		Console.WriteLine(ov);

		Console.ReadLine();
	}

	static public int CompareVersion(string version1, string version2)
	{
		Dictionary<int, int> v1;
		Dictionary<int, int> v2;

		FindVersion(version1, out v1);

		FindVersion(version2, out v2);

		if (v1.Count > v2.Count)
		{
			int ver = v2.Count + 1;

			for (int i = ver; i <= v1.Count; i++)
			{
				v2.Add(ver++, 0);
			}
		}
		else
		{
			int ver = v1.Count + 1;

			for (int i = ver; i <= v2.Count; i++)
			{
				v1.Add(ver++, 0);
			}
		}

		for (int i = 1; i < Math.Max(v1.Count, v2.Count) + 1; i++)
		{

			if (v1[i] > v2[i])
			{
				return 1;
			}
			else if (v1[i] < v2[i])
			{
				return -1;
			}
		}

		return 0;
	}

	static public void FindVersion(string version, out Dictionary<int, int> versionDict)
	{
		versionDict = new Dictionary<int, int>();
		int vers = 1;
		int numVer = 0;

		for (int i = 0; i < version.Length; i++)
		{
			if (version[i] != '.')
			{
				numVer += int.Parse(version[i].ToString());
				numVer *= 10;
			}
			else
			{
				numVer = numVer / 10;
				versionDict.Add(vers++, numVer);
				numVer = 0;
			}
		}
		numVer = numVer / 10;
		versionDict.Add(vers++, numVer);
	}


}