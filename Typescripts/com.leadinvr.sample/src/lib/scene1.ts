import { click, component, getLogger } from "zes-unity-jslib";

@component({ template: "Assets/com.leadinvr.sample/scenes/scene1.unity" })
export class Scene1 {
    @click("#button")
    onClickButton() {
        logger.info("button click");
    }
}

const logger = getLogger(Scene1.name);
