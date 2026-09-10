
interface YzDialogPars {
    title: string,
    hasClose?: boolean,
    hasFull?: boolean,
    hasMin?: boolean,
    width?: string,
    height?: string,
    comp: any,
    pars?: any,
}

interface YzDialogDto {
    show: boolean,
    full: boolean,
    min: boolean,
    pars: YzDialogPars,
}
interface YzDialogExpose {
    open: (pars: YzDialogPars) => void,
    close: () => void,
    full: () => void,
    min: () => void
}
export type {YzDialogExpose,YzDialogDto,YzDialogPars}