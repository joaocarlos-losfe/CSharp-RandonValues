using System;
using System.Threading.Tasks;

public enum GenerationType
{
	pattern,
	numeric,
	character,
	symbol,
	binary
}

public class RandonGenerateKey
{
	private byte defalt_len = 4;
	private const byte defalt_max_len = 30;

	private char[] symbols = { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};

	private Random randon_value = new Random();

	private string composite_string_key = "";

	public async Task <string> Generate(GenerationType type, byte len)
    {
		this.defalt_len = len;

		if (len < 4)
			this.defalt_len = 4;
		else if (len > 30)
			this.defalt_len = 30;
	
		string key = "";

		switch (type)
        {
			case GenerationType.pattern: key = await pattern(); break;

			case GenerationType.numeric: key = await numeric(); break;

			case GenerationType.character: key = await character(); break;

			case GenerationType.symbol: key = await symbol(); break;

			case GenerationType.binary: key =  binary(); break;
		}

		return key;
    }

	private async Task<string> pattern()
    {
		this.composite_string_key = "";

		const byte start_ascii_pattern = 33;
		const byte end_ascii_pattern = 126;

		await Task.Run(() =>
		{
			for (byte i = 0; i < this.defalt_len; i++)
			{
				composite_string_key += Convert.ToChar(this.randon_value.Next(start_ascii_pattern, end_ascii_pattern));
			}
		});

		return composite_string_key;
    }

	private async Task<string> numeric()
	{
		this.composite_string_key = "";

		const byte start_ascii_pattern = 48;
		const byte end_ascii_pattern = 57;

		await Task.Run(() =>
		{
			for (byte i = 0; i < this.defalt_len; i++)
			{
				composite_string_key += Convert.ToChar(this.randon_value.Next(start_ascii_pattern, end_ascii_pattern));
			}
		});

		return composite_string_key;
	}

	private async Task<string> character()
	{
		this.composite_string_key = "";

		const byte start_ascii_pattern = 65;
		const byte end_ascii_pattern = 122;

		int value_next = 0;

		await Task.Run(() =>
		{
			for (byte i = 0; i < this.defalt_len; i++)
			{
				value_next = this.randon_value.Next(start_ascii_pattern, end_ascii_pattern);

				while(value_next > 90 && value_next < 97)
					value_next = this.randon_value.Next(start_ascii_pattern, end_ascii_pattern);

				composite_string_key += Convert.ToChar(value_next);
			}
		});

		return composite_string_key;
	}

	private async Task <string> symbol()
	{
		this.composite_string_key = "";

		await Task.Run(() =>
		{
			for (byte i = 0; i < this.defalt_len; i++)
			{
				composite_string_key += symbols[this.randon_value.Next(0, symbols.Length - 1)];
			}
		});

		return composite_string_key;
	}

	private string binary()
	{
		return "..";
	}
}
