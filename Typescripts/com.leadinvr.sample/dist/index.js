"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.main = void 0;
require("reflect-metadata");
const zes_unity_jslib_1 = require("zes-unity-jslib");
const root_1 = require("./lib/root");
function main(id, assets, go) {
    (0, zes_unity_jslib_1.bootstrap)(id, assets, root_1.Root, go);
}
exports.main = main;
//# sourceMappingURL=index.js.map