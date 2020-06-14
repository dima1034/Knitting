import SwiftUI

struct Passthrough<Content>: View where Content: View {

    let content: () -> Content

    init(@ViewBuilder content: @escaping () -> Content) {
        self.content = content
    }

    var body: some View {
        content()
    }
}

Passthrough {
    Text("sdsdsd")
    Text("sdsdsd")
    Text("sdsdsd")
}
