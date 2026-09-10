import type{ SysMenuLeftOutput } from "@/api-services/generated"
interface HomeLeftProps {
    logo: string,
    menuList: Array<SysMenuLeftOutput>|null|undefined
}
interface PageTabData {
    title: string
    name: string
    content?: string,
    query?: Record<string, any>;
}
interface PageParsData {
    cols: [{
        align: string
        colspan: number,
        edit: boolean,
        event: string,
        field: string,
        fixed: string,
        hide: boolean,
        minWidth: number,
        rowsapan: number,
        singLeline: boolean,
        sort: boolean,
        style: string,
        templet: string,
        title: string,
        totalRow: boolean,
        totalRowText: string,
        type: string,
        unresize: boolean,
        width: string
    }],
    fBtns: [{
        className: string,
        funName: string,
        groupName: string,
        icon: string,
        isGroup: boolean,
        style: string,
        title: string,
    }],
    sFields: [{
        title: string,
        value: string,
        type: number,
        placeholder: string,
        data: [{
            label: string,
            vlaue: string,
            selected: boolean,
            disabeled: boolean
        }]
    }],
    pageConfig: {
        isTree: boolean,
        open: boolean,
        page: boolean
    },
    treeConfig: {
        iconIndex: number,
        treeDefaultClose: boolean,
        treeLinkage: boolean,
        treeSpid: number
    },
    tBtns: string,

}
export type { HomeLeftProps, PageTabData, PageParsData }