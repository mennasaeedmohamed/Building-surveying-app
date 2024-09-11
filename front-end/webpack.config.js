const webpack = require('webpack');

module.exports = {
    resolve: {
        fallback: {
            "crypto": require.resolve("crypto-browserify")
        }
    },
    plugins: [
        new webpack.ProvidePlugin({
            process: 'process/browser',
            Buffer: ['buffer', 'Buffer'],
        }),
        new webpack.EnvironmentPlugin({
            NODE_OPTIONS: '--openssl-legacy-provider',
        }),
    ],
};
