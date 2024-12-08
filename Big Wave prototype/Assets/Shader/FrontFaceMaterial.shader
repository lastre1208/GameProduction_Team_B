Shader "Unlit/FrontFaceMaterial"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FrontColor ("Front Color", Color) = (1, 1, 1, 1) // 前面用の色
        _BackColor ("Back Color", Color) = (1, 1, 1, 1) // 背面用の色
        _SideColor ("Side Color", Color) = (1, 1, 1, 1) // 側面用の色
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite On
            Blend Off
            Cull Back

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;    // 法線データを追加
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 localNormal : TEXCOORD1; // ワールド座標系の法線を渡す
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _FrontColor;
            fixed4 _BackColor;
            fixed4 _SideColor;

            // 頂点シェーダー
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                // オブジェクト空間の法線をワールド空間に変換
                o.localNormal = normalize(v.normal);

                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            // フラグメントシェーダー
            fixed4 frag (v2f i) : SV_Target
            {
                // 基本のテクスチャカラーを取得
                fixed4 col = tex2D(_MainTex, i.uv);

                float3 n = normalize(i.localNormal);

                // 前面、側面、背面の判定
                if (n.z < -0.5) // 前面（z が大きい）
                {
                    col *= _FrontColor;
                }
                else if (n.z > 0.5) // 背面（z が小さい）
                {
                    col = _BackColor;
                }
                else // 側面（z が前面や背面でない場合）
                {
                    col = _SideColor;
                }

                // フォグの適用
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}