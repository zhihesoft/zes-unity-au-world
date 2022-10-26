"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Scene1 = void 0;
const zes_unity_jslib_1 = require("zes-unity-jslib");
let Scene1 = class Scene1 {
    onClickButton() {
        logger.info("button click");
    }
};
__decorate([
    (0, zes_unity_jslib_1.click)("#button"),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], Scene1.prototype, "onClickButton", null);
Scene1 = __decorate([
    (0, zes_unity_jslib_1.component)({ template: "Assets/com.leadinvr.sample/scenes/scene1.unity" })
], Scene1);
exports.Scene1 = Scene1;
const logger = (0, zes_unity_jslib_1.getLogger)(Scene1.name);
//# sourceMappingURL=scene1.js.map