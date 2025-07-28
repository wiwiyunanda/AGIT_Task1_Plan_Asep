using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		string[] hari = { "Senin", "Selasa", "Rabu", "Kamis", "Jumat" };
		int[] asepPlan = new int[5];

		Console.WriteLine("Masukkan jumlah produksi mobil untuk masing-masing hari:");

		//validasi angka
		for (int i = 0; i < 5; i++)
		{
			Console.Write($"{hari[i]}: ");
			if (!int.TryParse(Console.ReadLine(), out asepPlan[i]))
			{
				Console.WriteLine("Input tidak valid. Harus berupa angka.");
				return;
			}
		}

		int total = asepPlan.Sum();
		int rata = total / 5;
		int sisa = total % 5;

		// Urutkan hari berdasarkan nilai input terbesar
		var NewProd = asepPlan
			.Select((value, index) => new { value, index })
			.OrderByDescending(x => x.value)
			.Select(x => x.index)
			.ToList();

		// new plan dengan nilai rata-rata
		int[] resultPlan = Enumerable.Repeat(rata, 5).ToArray();

		// Tambahkan sisa prod ke hari dgn produksi awal terbesar
		for (int i = 0; i < sisa; i++)
		{
			resultPlan[NewProd[i]] += 1;
		}

		Console.WriteLine("\n--- Hasil Rencana Produksi Baru ---");
		for (int i = 0; i < 5; i++)
		{
			Console.WriteLine($"{hari[i]}: {resultPlan[i]}");
		}

		Console.WriteLine($"\nTotal Produksi Tetap: {resultPlan.Sum()} mobil");
		Console.ReadLine();
	}
}
