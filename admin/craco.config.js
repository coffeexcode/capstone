const path = require('path')

module.exports = {
  webpack: {
    alias: {
      "@utils": path.resolve(__dirname, './src/utils'),
      "@admin": path.resolve(__dirname, './src/components/admin'),
      "@components": path.resolve(__dirname, './src/components')
    },
  },
}