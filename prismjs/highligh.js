export function highlight(text) {
  const renderedCodeBlock = Prism.highlight(text, Prism.languages.aspnet, 'aspnet');

  return renderedCodeBlock;
}