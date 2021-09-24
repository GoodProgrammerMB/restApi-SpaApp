import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'eNumName',
})
export class EnumNamePipe implements PipeTransform {
  transform(input: any, data: object) {
    //return data[input];
  }
}
