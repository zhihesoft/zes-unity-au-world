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
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Root = void 0;
const zes_unity_jslib_1 = require("zes-unity-jslib");
const logger_1 = require("zes-unity-jslib/dist/lib/logger");
const scene1_1 = require("./scene1");
let Root = class Root {
    constructor(view) {
        this.view = view;
    }
    // @bind("#label")
    // label!: CS.TMPro.TMP_Text;
    zesOnInit() {
        return __awaiter(this, void 0, void 0, function* () {
            CS.Au.Fader.FadeIn(2);
            logger.debug(`root start`);
            const scene1 = new zes_unity_jslib_1.ViewRef(scene1_1.Scene1, this.view);
            scene1.show();
        });
    }
};
Root = __decorate([
    (0, zes_unity_jslib_1.component)(),
    __metadata("design:paramtypes", [zes_unity_jslib_1.ViewRef])
], Root);
exports.Root = Root;
const logger = (0, logger_1.getLogger)(Root.name);
//# sourceMappingURL=root.js.map