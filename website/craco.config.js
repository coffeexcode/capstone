const path = require('path')

module.exports = {
  webpack: {
    alias: {
      "@utils": path.resolve(__dirname, './src/utils'),
      "@admin": path.resolve(__dirname, './src/components/admin'),
      "@browser": path.resolve(__dirname, './src/components/browser'),
      "@attendee": path.resolve(__dirname, './src/components/attendee'),
      "@product": path.resolve(__dirname, './src/components/product'),
      "@components": path.resolve(__dirname, './src/components'),
      "@public": path.resolve(__dirname, './public')
    },
  },
}