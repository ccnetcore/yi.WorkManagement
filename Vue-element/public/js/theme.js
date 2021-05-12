function navbarBg(num) {
    switch (num) {
        case "1":
            return "#1E222D"
            break;
        case "2":
            return "#66CCFF"
            break;
        case "3":
            return "#FFCC99"
            break;
        default:
            return "#1E222D"
            break;
    }
}

function headerBg(num) {
    switch (num) {
        case "1":
            return "#262F3e"
            break;
        case "2":
            return "#00CCFF"
            break;
        case "3":
            return "#FFCC66"
            break;
        default:
            return "#262F3e"
            break;
    }
}

function navbarColor(num) {
    switch (num) {
        case "1":
            return "#C1C6C8"
            break;
        case "2":
            return "#0099FF"
            break;
        case "3":
            return "#FF9933"
            break;
        default:
            return "#C1C6C8"
            break;
    }
}
export {
    navbarBg,
    headerBg,
    navbarColor
}