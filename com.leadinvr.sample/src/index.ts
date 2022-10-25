import "reflect-metadata";
import { bootstrap } from "zes-unity-jslib";
import { Root } from "./lib/root";

export function main(
    id: string,
    assets: CS.Au.AssetSet,
    go: CS.UnityEngine.GameObject
) {
    bootstrap(id, assets, Root, go);
}
