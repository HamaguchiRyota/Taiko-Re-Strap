using System;
using System.Collections.Generic;
using System.Text;

namespace TJAPlayer3
{
	/// <summary>
	/// <para>DTXMania のバージョン。</para>
	/// <para>例1："078b" → 整数部=078, 小数部=2000000 ('英字'+'yymmdd') </para>
	/// <para>例2："078a(100124)" → 整数部=078, 小数部=1100124 ('英字'+'yymmdd')</para>
	/// </summary>
    public class CDTXVersion
	{
		// プロパティ

		/// <summary>
		/// <para>バージョンが未知のときに true になる。</para>
		/// </summary>
		public bool Unknown
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>DTXMania のバージョンの整数部を表す。</para>
		/// <para>例1："078b" → 整数部=078</para>
		/// <para>例2："078a(100124)" → 整数部=078</para>
		/// </summary>
		public int n整数部;

		/// <summary>
		/// <para>DTXMania のバージョンの小数部を表す。</para>
		/// <para>小数部は、'英字(0～26) * 1000000 + 日付(yymmdd)' の式で表される整数。</para>
		/// <para>例1："078b" → 小数部=2000000 </para>
		/// <para>例2："078a(100124)" → 小数部=1100124</para>
		/// </summary>
		public int n小数部;


		// コンストラクタ

		public CDTXVersion( string Version )
		{
			this.n整数部 = 0;
			this.n小数部 = 0;
			this.Unknown = true;
			
			if( Version.ToLower().Equals( "unknown" ) )
			{
				this.Unknown = true;
			}
			else
			{
				int num = 0;
				int length = Version.Length;
				if( ( num < length ) && char.IsDigit( Version[ num ] ) )
				{
					// 整数部　取得
					while( ( num < length ) && char.IsDigit( Version[ num ] ) )
					{
						this.n整数部 = ( this.n整数部 * 10 ) + CDTXVersion.DIG10.IndexOf( Version[ num++ ] );
					}

					// 小数部(1)英字部分　取得
					while( ( num < length ) && ( ( Version[ num ] == ' ' ) || ( Version[ num ] == '(' ) ) )
					{
						num++;
					}
					if( ( num < length ) && ( CDTXVersion.DIG36.IndexOf( Version[ num ] ) >= 10 ) )
					{
						this.n小数部 = CDTXVersion.DIG36.IndexOf( Version[ num++ ] ) - 10;
						if( this.n小数部 >= 0x1a )
						{
							this.n小数部 -= 0x1a;
						}
						this.n小数部++;
					}

					// 小数部(2)日付部分(yymmdd)　取得
					while( ( num < length ) && ( ( Version[ num ] == ' ' ) || ( Version[ num ] == '(' ) ) )
					{
						num++;
					}
					for( int i = 0; i < 6; i++ )
					{
						this.n小数部 *= 10;
						if( ( num < length ) && char.IsDigit( Version[ num ] ) )
						{
							this.n小数部 += CDTXVersion.DIG10.IndexOf( Version[ num ] );
						}
						num++;
					}
					this.Unknown = false;
				}
				else
				{
					this.Unknown = true;
				}
			}
		}
	
		// メソッド

		// その他

		#region [ private ]
		//-----------------
		private const string DIG36 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string DIG10 = "0123456789";
		//-----------------
		#endregion
	}
}
