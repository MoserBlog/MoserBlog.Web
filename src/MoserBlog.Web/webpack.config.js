const path = require('path');

const CopyPlugin = require("copy-webpack-plugin");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
    mode: 'production',
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist')
    },
    plugins: [
        new CopyPlugin({
            patterns: [
              { from: "node_modules/moserblogweb-styles/dist" }
            ]
        }),
        new CleanWebpackPlugin()
    ]
}