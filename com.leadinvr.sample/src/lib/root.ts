import { component, OnInit, ViewRef } from "zes-unity-jslib";
import { getLogger } from "zes-unity-jslib/dist/lib/logger";
import { Scene1 } from "./scene1";

@component()
export class Root implements OnInit {

    constructor(
        private view: ViewRef
    ) { }

    // @bind("#label")
    // label!: CS.TMPro.TMP_Text;

    async zesOnInit() {
        CS.Au.Fader.FadeIn(2);
        logger.debug(`root start`);
        const scene1 = new ViewRef(Scene1, this.view);
        scene1.show();
    }
}

const logger = getLogger(Root.name);

