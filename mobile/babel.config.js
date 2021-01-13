module.exports = function(api) {
  api.cache(true);
  return {
    presets: ['babel-preset-expo'],
    plugins: [
      [
        "module-resolver", {
          alias: {
            '@images': './assets/images',
            '@data': './assets/data',
            '@tabs': './src/tabs',
            '@core': './src/core',
            '@screens': './src/screens',
            '@utils': './src/utils',
          }
        }
      ]
    ]
  };
};
