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
            '@tabs': './components/tabs',
            '@core': './components/core',
            '@screens': './components/screens'
          }
        }
      ]
    ]
  };
};
