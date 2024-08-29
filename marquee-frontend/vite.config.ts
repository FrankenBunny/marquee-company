import { defineConfig, UserConfig } from 'vite';
import react from "@vitejs/plugin-react";
import { resolve } from 'path'; 

export default defineConfig(({command, mode }): UserConfig => {
  const commonConfig: UserConfig = {
    base: "/",
    plugins: [react()],
    resolve: {
      alias: {
        '@': resolve(__dirname, './src'), // Adjust the path if your source folder is named differently
      },
    },
  };

  if (command === "serve") {
    return {
      ...commonConfig,
      server: {
        port: 8080,
        strictPort: true,
        host: true,
        origin: "http://localhost:3000",
      }
    }
  } else {
    return {
      ...commonConfig,
      build: {
        outDir: "dist",
        sourcemap: false,
      },
      preview: {
        port: 3000,
        strictPort: true,
      }
    }
  }
});