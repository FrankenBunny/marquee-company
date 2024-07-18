/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: ["class"],
  content: [
    "./pages/**/*.{ts,tsx}",
    "./components/**/*.{ts,tsx}",
    "./app/**/*.{ts,tsx}",
    "./src/**/*.{ts,tsx}",
  ],
  prefix: "",
  theme: {
    container: {
      center: true,
      padding: "2rem",
      screens: {
        "2xl": "1400px",
      },
    },
    extend: {
      colors: {
        marquee_blue: {
          100: "#CCDBEB",
          200: "#99B8D7",
          300: "#6694C3",
          400: "#3371AF",
          500: "#004D9B",
          600: "#003E7C",
          700: "#002E5D",
          800: "#00274E",
          900: "#000F1F",
        },
        marquee_red: {
          100: "#FCD4DD",
          200: "#F9AABB",
          300: "#F57F98",
          400: "#F25576",
          500: "#EF2A54",
          600: "#BF2243",
          700: "#8F1932",
          800: "#601122",
          900: "#300811",
        },
        marquee_green: {
          100: "#D1F1EC",
          200: "#A3E3D9",
          300: "#76D6C6",
          400: "#48C8B3",
          500: "#1ABAA0",
          600: "#159580",
          700: "#107060",
          800: "#0A4A40",
          900: "#052520",
        },
        marquee_yellow: {
          100: "#FDFAE4",
          200: "#FAF0B7",
          300: "#F7E788",
          400: "#F4DD58",
          500: "#F0D328",
          600: "#D7BA0F",
          700: "#A7900B",
          800: "#776708",
          900: "#181502",
        },
        marquee_neutral: {
          100: "#F9FBFD",
          200: "#DBDBDD",
          300: "#B7B7BC",
          400: "#92939A",
          500: "#6E6F79",
          600: "#4A4B57",
          700: "#3B3C46",
          800: "#2C2D34",
          900: "#1E1E23",
        },
        border: "hsl(var(--border))",
        input: "hsl(var(--input))",
        ring: "hsl(var(--ring))",
        background: "hsl(var(--background))",
        foreground: "hsl(var(--foreground))",
        primary: {
          DEFAULT: "#004D9B",
          foreground: "hsl(var(--primary-foreground))",
        },
        secondary: {
          DEFAULT: "hsl(var(--secondary))",
          foreground: "hsl(var(--secondary-foreground))",
        },
        destructive: {
          DEFAULT: "hsl(var(--destructive))",
          foreground: "hsl(var(--destructive-foreground))",
        },
        muted: {
          DEFAULT: "hsl(var(--muted))",
          foreground: "hsl(var(--muted-foreground))",
        },
        accent: {
          DEFAULT: "hsl(var(--accent))",
          foreground: "hsl(var(--accent-foreground))",
        },
        popover: {
          DEFAULT: "hsl(var(--popover))",
          foreground: "hsl(var(--popover-foreground))",
        },
        card: {
          DEFAULT: "hsl(var(--card))",
          foreground: "hsl(var(--card-foreground))",
        },
      },
      borderRadius: {
        lg: "var(--radius)",
        md: "calc(var(--radius) - 2px)",
        sm: "calc(var(--radius) - 4px)",
      },
      keyframes: {
        "accordion-down": {
          from: { height: "0" },
          to: { height: "var(--radix-accordion-content-height)" },
        },
        "accordion-up": {
          from: { height: "var(--radix-accordion-content-height)" },
          to: { height: "0" },
        },
      },
      animation: {
        "accordion-down": "accordion-down 0.2s ease-out",
        "accordion-up": "accordion-up 0.2s ease-out",
      },
    },
  },
  plugins: [require("tailwindcss-animate")],
};
